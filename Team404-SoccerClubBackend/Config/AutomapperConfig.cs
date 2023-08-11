using AutoMapper;
using DomainLayer.Dtos.ClubHistory;
using DomainLayer.Dtos.Competition;
using DomainLayer.Dtos.Matches;
using DomainLayer.Dtos.MatchStats;
using DomainLayer.Dtos.Order;
using DomainLayer.Dtos.OrderItem;
using DomainLayer.Dtos.Player;
using DomainLayer.Dtos.PlayerAchievement;
using DomainLayer.Dtos.PlayerImages;
using DomainLayer.Dtos.PlayerStats;
using DomainLayer.Dtos.Product;
using DomainLayer.Dtos.ProductCategory;
using DomainLayer.Dtos.RoleDto;
using DomainLayer.Dtos.SoccerInfo;
using DomainLayer.Dtos.Team;
using DomainLayer.Dtos.TeamStats;
using DomainLayer.Dtos.UsersDto;
using DomainLayer.Models;

namespace Team404_SoccerClubBackend.Config
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            //User Mapping
            CreateMap<Users, UsersDto>().ReverseMap();
            CreateMap<Users, UsersResultDto>().ReverseMap();

            //Roles Mapping
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Role, RoleResultDto>().ReverseMap();

            //TeamStats Mapping
            CreateMap<TeamStats, TeamStatsDto>().ReverseMap();
            CreateMap<TeamStats, TeamStatsResultDto>().ReverseMap();

            //Team Mapping
            CreateMap<Team, TeamDto>().ReverseMap();
            CreateMap<Team, TeamResultDto>().ReverseMap();

            //SoccerInfo Mapping
            CreateMap<SoccerInfo, SoccerInfoDto>().ReverseMap();
            CreateMap<SoccerInfo, SoccerInfoResultDto>().ReverseMap();

            //ProductCategory Mapping
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryResultDto>().ReverseMap();

            //Product Mapping
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductResultDto>().ReverseMap();

            //PlayerStats Mapping
            CreateMap<PlayerStats, PlayerStatsDto>().ReverseMap();
            CreateMap<PlayerStats, PlayerStatsResultDto>().ReverseMap();

            //PlayerImages Mapping
            CreateMap<PlayerImages, PlayerImagesDto>().ReverseMap();
            CreateMap<PlayerImages, PlayerImagesResultDto>().ReverseMap();

            //PlayerAchievement Mapping
            CreateMap<PlayerAchievement, PlayerAchievementDto>().ReverseMap();
            CreateMap<PlayerAchievement, PlayerAchievementResultDto>().ReverseMap();

            //Player Mapping
            CreateMap<Player, PlayerDto>().ReverseMap();
            CreateMap<Player, PlayerResultDto>().ReverseMap();

            //OrderItem Mapping
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemResultDto>().ReverseMap();

            //Order Mapping
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderResultDto>().ReverseMap();

            //MatchStats Mapping
            CreateMap<MatchStats, MatchStatsDto>().ReverseMap();
            CreateMap<MatchStats, MatchStatsResultDto>().ReverseMap();

            //Matches Mapping
            CreateMap<Matches, MatchesDto>().ReverseMap();
            CreateMap<Matches, MatchesResultDto>().ReverseMap();

            //Competition Mapping
            CreateMap<Competition, CompetitionDto>().ReverseMap();
            CreateMap<Competition, CompetitionResultDto>().ReverseMap();

            //ClubHistory Mapping
            CreateMap<ClubHistory, ClubHistoryDto>().ReverseMap();
            CreateMap<ClubHistory, ClubHistoryResultDto>().ReverseMap();
        }
    }
}
