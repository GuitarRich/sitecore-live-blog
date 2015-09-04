namespace PokerCentral.Website.Pipelines.Initialize
{
	using System.Web.Mvc;

	//public class IoCContainerInitialization
 //   {
	//	public virtual void Process(PipelineArgs args)
	//	{
	//		var container = new Container();
	//		container.Options.ConstructorResolutionBehavior = new DefaultFirstConstructorBehavior();

	//		// Register the Sitecore controller factories
	//		container.RegisterSingle<ISimpleInjectorControllerFactory, SimpleInjectorControllerFactory>();
	//		container.RegisterSingle<ISimpleInjectorSitecoreControllerFactory, SimpleInjectorSitecoreControllerFactory>();

	//		InitializeContainer(container);

	//		//container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

	//		// container.RegisterMvcAttributeFilterProvider();
	//		// container.RegisterMvcIntegratedFilterProvider();

	//		container.Verify();

	//		DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

	//		var sitecoreControllerFactory = new SimpleInjectorSitecoreControllerFactory(new SimpleInjectorControllerFactory(container));
	//		ControllerBuilder.Current.SetControllerFactory(sitecoreControllerFactory);

	//		// Initialize Fortis for Sitecore Pipelines
	//		Global.Initialise(
	//			DependencyResolver.Current.GetService<ISpawnProvider>(),
	//			DependencyResolver.Current.GetService<IItemFactory>(),
	//			DependencyResolver.Current.GetService<IItemSearchFactory>());
 //       }

	//	private static void InitializeContainer(Container container)
	//	{
	//		// Register Fortis
	//		container.Register<IContextProvider, ContextProvider>();
	//		container.Register<IModelAssemblyProvider, ModelAssemblyProvider>();
	//		container.Register<ISearchResultsAdapter, SearchResultsAdapter>();
	//		container.Register<ISpawnProvider, SpawnProvider>(); 
	//		container.Register<ITemplateMapProvider, TemplateMapProvider>();

	//		// Fortis item factory
	//		container.Register<IItemFactory, CustomItemFactory>(Lifestyle.Singleton);
	//		container.Register<ICustomItemFactory, CustomItemFactory>(Lifestyle.Singleton);
	//		container.Register<IItemSearchFactory, ItemSearchFactory>(Lifestyle.Singleton);

	//		// Rendering Context Services
	//		container.RegisterOpenGeneric(typeof(IRenderingContext<,>), typeof(RenderingContext<,>));
	//		container.RegisterOpenGeneric(typeof(IRenderingItemContext<>), typeof(RenderingItemContext<>));
	//		container.RegisterOpenGeneric(typeof(IRenderingParametersContext<>), typeof(RenderingParametersContext<>));

	//		// Phrase Manager
	//		container.Register<IPhraseManager, PhraseManager>();

	//		// LM Logging Manager
	//		container.Register<ILoggingProvider, IgniteLoggingProvider>();
	//		container.RegisterAll<ILoggingProvider>(typeof(IgniteLoggingProvider));
	//		container.Register<ILoggingManager, LoggingManager>();

	//		// Site Manager
	//		container.RegisterPerWebRequest<ISiteManager, SiteManager>();
	//		container.RegisterPerWebRequest<ISettingsManager, SettingsManager>();

	//		// Meta Data Services
	//		container.Register<IMetaDataService, MetaDataService>();

	//		// Navigation
	//		container.Register<INavigationService, NavigationService>();

	//		// News and Media
	//		container.Register<IMediaService, MediaService>();
 //           container.Register<IVideoService, VideoService>();

	//		// Contests
	//		container.Register<IContestsService, ContestsService>();

	//		//News
	//		container.Register<INewsService, NewsService>();

	//		//Social Feed
	//		container.Register<ISocialFeed<TwitterStatus>, TwitterFeed>();

 //           //Shows and Schedules
 //           container.Register<IExternalDataProvider, ExternalSqlDataProvider>();
 //           container.Register<IScheduleManager, ScheduleManager>();

 //           // Search Manager
 //           container.Register(typeof(ISearchManager),
 //               () => new SearchManager(
 //                   new SearchIndex("sitecore_master_index"),
 //                   new SearchIndex("sitecore_core_index"),
 //                   new SearchIndex("sitecore_web_index")),
 //               Lifestyle.Singleton);

	//		// Exact Target
	//		container.Register<IMailListService<PokerCentralListAttributes>, ExactTargetGateway>();

	//		container.Register<IConfigurationManager, IgniteConfigurationManager>();
	//	}
 //   }
}