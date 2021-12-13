using AutoMapper;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Persistence;
using Notes.Tests.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Notes.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteDetailsQueryHandlerTests
    {
        private readonly NotesDbContext _context;
        private readonly IMapper _mapper;

        public GetNoteDetailsQueryHandlerTests(QueryTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public async Task GetNoteDetailsQueryHandler_Success()
        {
            //Assign
            var handler = new GetNoteDetailsQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetNoteDetailsQuery
                {
                    UserId = NotesContextFactory.UserBId,
                    Id = Guid.Parse("{0A1D46E6-8697-466A-9047-6602AB828A0A}")
                },
                CancellationToken.None);

            //Assert
            result.ShouldBeOfType<NoteDetailsVm>();
            result.Title.ShouldBe("Title2");
            result.DateOfCreation.ShouldBe(DateTime.Today);
        }
    }

    //[CollectionDefinition("QueryCollection")]
    //public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
