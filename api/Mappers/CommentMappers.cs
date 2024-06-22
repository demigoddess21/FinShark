using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Model;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comments commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId


            };
        }

        public static Comments ToCmmentFromCreate(this CreateCommentDto createCommentDto, int stockId)
        {
            return new Comments
            {
                Title = createCommentDto.Title,
                Content = createCommentDto.Content,
                StockId = stockId


            };
        }
    }
}