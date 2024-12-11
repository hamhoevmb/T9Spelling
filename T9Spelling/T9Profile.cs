using AutoMapper;

namespace T9Spelling;

public class T9Profile : Profile
{
    public T9Profile(Dictionary<char, string> t9Mapping)
    {
        CreateMap<char, string>()
            .ConvertUsing((src, _) => t9Mapping.GetValueOrDefault(src, ""));
    }
}