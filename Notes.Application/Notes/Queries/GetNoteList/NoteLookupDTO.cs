using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class NoteLookupDTO : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookupDTO>()
                .ForMember(noteDTO => noteDTO.Title,
                    opt => opt.MapFrom(note => note.Title))
                .ForMember(noteDTO => noteDTO.Id,
                    opt => opt.MapFrom(note => note.Id));
        }
    }
}
