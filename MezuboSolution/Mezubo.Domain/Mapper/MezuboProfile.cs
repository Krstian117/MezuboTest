namespace Mezubo.Domain.Mapper
{
    using AutoMapper;
    using Mezubo.Domain.ModelServices.Bet;

    public class MezuboProfile : Profile
    {

        public MezuboProfile()
        {
            this.CreateMap<BetDto, CreateBetRequest>().ReverseMap();
        }
    }
}
