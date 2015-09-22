namespace LiveBlog.Website.Pipelines.Response.RenderPlaceholder
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Sitecore;
	using Sitecore.Data;
	using Sitecore.Data.Fields;
	using Sitecore.Data.Items;
	using Sitecore.Diagnostics;
	using Sitecore.Mvc.Extensions;
	using Sitecore.Mvc.Pipelines.Response.RenderPlaceholder;
	using Sitecore.Mvc.Presentation;

	public class PerformRenderingForSinglePageApplication : PerformRendering
	{
		/// <summary>
		/// Override the standard get renderings for placeholder. Looks for a fallback device and uses the renderings
		/// from that device instead of the current device
		/// </summary>
		/// <param name="placeholderName">
		/// The placeholder name.
		/// </param>
		/// <param name="args">
		/// The <see cref="RenderPlaceholderArgs"/> for the pipeline
		/// </param>
		/// <returns>
		/// An <see cref="IEnumerable"/> of <see cref="Rendering"/> objects for the current placeholder/device
		/// </returns>
		protected override IEnumerable<Rendering> GetRenderings(string placeholderName, RenderPlaceholderArgs args)
		{
			var placeholderPath = PlaceholderContext.Current.ValueOrDefault(context => context.PlaceholderPath).OrEmpty();
			var deviceId = this.GetPageDeviceId(args);

			// Get the current device
			var device = Context.Resources.Devices[new ID(deviceId)];
			var usingFallbackDevice = false;

			var ajaxDevice = device.InnerItem["ajax device"];
			if (string.IsNullOrWhiteSpace(ajaxDevice) == false)
			{
				Tracer.Info($"Current device is an AJAX device, using renderings from the fallback device [{ajaxDevice}]");

				// Get the renderings from the fallback device
				deviceId = Guid.Parse(ajaxDevice);
				usingFallbackDevice = true;
			}

			var renderings = new List<Rendering>();
			renderings.AddRange(
				args.PageContext.PageDefinition.Renderings.Where(
					r =>
					{
						if (!(r.DeviceId == deviceId))
						{
							return false;
						}

						return r.Placeholder.EqualsText(placeholderName) || r.Placeholder.EqualsText(placeholderPath);
					}));

			var renderingItems = renderings.ToList();
			if (usingFallbackDevice)
			{
				// Check each rendering for an ajax version
				foreach (var rendering in renderings)
				{
					var ajaxRendering = this.GetAjaxVersion(rendering);
					if (ajaxRendering != null)
					{
						// There is an ajax version, so insert it into the same place as
						// the original rendering and remove the original.
						var indexOfRendering = renderingItems.IndexOf(rendering);
						renderingItems.Insert(indexOfRendering, ajaxRendering);
						renderingItems.Remove(rendering);
					}
				}
			}

			return renderingItems;
		}

		/// <summary>
		/// Attempts to get an ajax version of the supplied rendering.
		/// </summary>
		/// <param name="rendering">The original <see cref="Rendering"/> to base the search from</param>
		/// <returns>The Ajax version of the original <see cref="Rendering"/>. Null if no ajax version is found.</returns>
		private Rendering GetAjaxVersion(Rendering rendering)
		{
			if (rendering == null || string.IsNullOrWhiteSpace(rendering.RenderingItemPath))
			{
				return null;
			}

			var renderingItem = this.Database.GetItem(rendering.RenderingItemPath);
			InternalLinkField ajaxLinkField = renderingItem.Fields["ajax rendering"];
			if (ajaxLinkField == null)
			{
				return null;
			}

			var ajaxRenderingDatabaseItem = this.Database.GetItem(ajaxLinkField.TargetID);
			if (ajaxRenderingDatabaseItem == null)
			{
				return null;
			}

			// Build the ajax rendering item
			var ajaxRenderingItem = new Rendering
			{
				RenderingItem = new RenderingItem(ajaxRenderingDatabaseItem),
				Caching = rendering.Caching,
				ChildRenderings = rendering.ChildRenderings,
				DataSource = rendering.DataSource,
				DeviceId = rendering.DeviceId,
				Item = rendering.Item,
				LayoutId = rendering.LayoutId,
				Model = rendering.Model,
				Parameters = rendering.Parameters,
				Placeholder = rendering.Placeholder,
				RenderingItemPath = ajaxRenderingDatabaseItem.ID.ToString(),
			};

			return ajaxRenderingItem;
		}

		/// <summary>
		/// Gets the correct sitecore database.
		/// </summary>
		private Database Database
		{
			get
			{
				return Context.Database ?? Context.ContentDatabase;
			}
		}
	}
}
