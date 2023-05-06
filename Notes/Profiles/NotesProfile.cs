using AutoMapper;
using Notes.DBModels;
using Notes.Dtos;

namespace Notes.Profiles
{
    public class NotesProfile : Profile
    {
        public NotesProfile()
        {
            CreateMap<Note, NoteReadDto>();
            CreateMap<NoteWriteDto, Note>();
        }
    }
}
