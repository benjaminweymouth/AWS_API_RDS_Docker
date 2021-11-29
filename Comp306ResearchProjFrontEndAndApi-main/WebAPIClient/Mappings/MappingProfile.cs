using AutoMapper;
using FinancialLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIClient.DTOs;

namespace WebAPIClient.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<DbdataforStockVolatility, DbdataforStockVolatilityDto>();  //map from stock data to stockDTO
            CreateMap<SurveyInfoTable, SurveyInfoTableDto>();  //map from survey data to survey DTO 

        }
    }
}
