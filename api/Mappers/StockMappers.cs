using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Model;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                MarketCap = stockModel.MarketCap,
                Industry = stockModel.Industry,
                Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()


            };
        }

        public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockModel)
        {
            return new Stock
            {

                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                MarketCap = stockModel.MarketCap,
                Industry = stockModel.Industry


            };
        }

    }
}