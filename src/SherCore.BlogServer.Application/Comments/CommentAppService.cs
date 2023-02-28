using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Comments
{
    [Authorize()]
    [RemoteService(IsEnabled = false)]
    public class CommentAppService : BlogServerAppService, ICommentAppService
    {
        private readonly IRepository<Comment, Guid> _commentRepository;

        public CommentAppService(
            IRepository<Comment, Guid> commentRepository)
        {
        }

        public Task<CommentDto> CreateAsync(CommentCreateDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CommentDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<CommentDto>> GetListAsync(CommentRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<CommentDto> UpdateAsync(Guid id, CommentUpdateDto input)
        {
            throw new NotImplementedException();
        }
    }
}