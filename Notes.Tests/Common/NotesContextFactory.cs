using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Tests.Common
{
    public class NotesContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid NoteIdForDelete = Guid.NewGuid();
        public static Guid NoteIdForUpdate = Guid.NewGuid();

        public static NotesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<NotesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new NotesDbContext(options);
            context.Database.EnsureCreated();
            context.Notes.AddRange(
                new Note
                {
                    DateOfCreation = DateTime.Today,
                    Details = "Details1",
                    EditDate = null,
                    Title = "Title1",
                    Id = Guid.Parse("{174DB219-432B-4947-9472-420B670A1235}"),
                    UserId = UserAId
                },
                new Note
                {
                    DateOfCreation = DateTime.Today,
                    Details = "Details2",
                    EditDate = null,
                    Title = "Title2",
                    Id = Guid.Parse("{0A1D46E6-8697-466A-9047-6602AB828A0A}"),
                    UserId = UserBId
                },
                new Note
                {
                    DateOfCreation = DateTime.Today,
                    Details = "Details3",
                    EditDate = null,
                    Title = "Title3",
                    Id = NoteIdForDelete,
                    UserId = UserAId
                },
                new Note
                {
                    DateOfCreation = DateTime.Today,
                    Details = "Details4",
                    EditDate = null,
                    Id = NoteIdForUpdate,
                    Title = "Title4",
                    UserId = UserBId
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(NotesDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
