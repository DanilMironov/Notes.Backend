using Notes.Application.Common.Mappings;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class NoteListVm : IMapWith<Note>
    {
        public IList<NoteLookupDTO> Notes { get; set; }
    }
}
