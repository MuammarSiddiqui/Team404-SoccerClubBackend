﻿using ApplicationLayer.Services.CartService;
using ApplicationLayer.Services.ClubHistoryService;
using ApplicationLayer.Services.CompetitionService;
using ApplicationLayer.Services.ContactUsService;
using ApplicationLayer.Services.FeedbackService;
using ApplicationLayer.Services.MatchesService;
using ApplicationLayer.Services.MatchStatsService;
using ApplicationLayer.Services.NewsService;
using ApplicationLayer.Services.OrderItemService;
using ApplicationLayer.Services.OrderService;
using ApplicationLayer.Services.PlayerAchievementService;
using ApplicationLayer.Services.PlayerImagesService;
using ApplicationLayer.Services.PlayerService;
using ApplicationLayer.Services.PlayerStatsService;
using ApplicationLayer.Services.ProductCategoryService;
using ApplicationLayer.Services.ProductService;
using ApplicationLayer.Services.RoleService;
using ApplicationLayer.Services.SoccerInfoService;
using ApplicationLayer.Services.TeamService;
using ApplicationLayer.Services.TeamStatsService;
using ApplicationLayer.Services.UserAddressesService;
using ApplicationLayer.Services.UsersService;
using Infrastructure;
using Infrastructure.Repositories.CartRepository;
using Infrastructure.Repositories.ClubHistoryRepository;
using Infrastructure.Repositories.CompetitionRepository;
using Infrastructure.Repositories.ContactUsRepository;
using Infrastructure.Repositories.FeedbackRepository;
using Infrastructure.Repositories.MatchesRepository;
using Infrastructure.Repositories.MatchStatsRepository;
using Infrastructure.Repositories.NewsRepository;
using Infrastructure.Repositories.OrderItemRepository;
using Infrastructure.Repositories.OrderRepository;
using Infrastructure.Repositories.PlayerAchievementRepository;
using Infrastructure.Repositories.PlayerImagesRepository;
using Infrastructure.Repositories.PlayerRepository;
using Infrastructure.Repositories.PlayerStatsRepository;
using Infrastructure.Repositories.ProductCategoryRepository;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.Repositories.RoleRepository;
using Infrastructure.Repositories.SoccerInfoRepository;
using Infrastructure.Repositories.TeamRepository;
using Infrastructure.Repositories.TeamStatsRepository;
using Infrastructure.Repositories.UserAddressesRepository;
using Infrastructure.Repositories.UsersReposiotry;
using Team404_SoccerClubBackend.Config.File;

namespace Team404_SoccerClubBackend.Config
{
    public static class DIConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyContext>();


            services.AddScoped<ITeamStatsRepository, TeamStatsRepository>();
            services.AddScoped<ITeamStatsService, TeamStatsService>();

            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ITeamService, TeamService>();

            services.AddScoped<ISoccerInfoRepository, SoccerInfoRepository>();
            services.AddScoped<ISoccerInfoService, SoccerInfoService>();


            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IPlayerStatsRepository, PlayerStatsRepository>();
            services.AddScoped<IPlayerStatsService, PlayerStatsService>();

            services.AddScoped<IPlayerImagesRepository, PlayerImagesRepository>();
            services.AddScoped<IPlayerImagesService, PlayerImagesService>();

            services.AddScoped<IPlayerAchievementRepository, PlayerAchievementRepository>();
            services.AddScoped<IPlayerAchievementService, PlayerAchievementService>();

            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IPlayerService, PlayerService>();

            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderItemService, OrderItemService>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IMatchStatsRepository, MatchStatsRepository>();
            services.AddScoped<IMatchStatsService, MatchStatsService>();

            services.AddScoped<IMatchesRepository, MatchesRepository>();
            services.AddScoped<IMatchesService, MatchesService>();

            services.AddScoped<ICompetitionRepository, CompetitionRepository>();
            services.AddScoped<ICompetitionService, CompetitionService>();

            //User
            services.AddScoped<IUsersRepository, UserRepository>();
            services.AddScoped<IUsersService, UsersService>();


            //Roles
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();


            //ClubHistory
            services.AddScoped<IClubHistoryRepository, ClubHistoryRepository>();
            services.AddScoped<IClubHistoryService, ClubHistoryService>();



            //Cart
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartService, CartService>();


            //UserAddresses
            services.AddScoped<IUserAddressesRepository, UserAddressesRepository>();
            services.AddScoped<IUserAddressesService, UserAddressesService>();


            //ContactUs
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IContactUsService, ContactUsService>();


            //Feedback
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackService, FeedbackService>();


            //News
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsService, NewsService>();
            
            //File
            services.AddScoped<IFileUpload, FileUpload>();

            return services;
        }
    }
}
