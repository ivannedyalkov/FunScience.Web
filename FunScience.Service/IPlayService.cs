namespace FunScience.Service.Admin
{
    using FunScience.Service.Admin.Models.Play;
    using System.Collections.Generic;

    public interface IPlayService
    {
        bool AddPlay(string name);

        bool Edit(int id, string name);

        PlayListingModel PlayInfo(int id);

        void Delete(int id);

        IEnumerable<PlayListingModel> ListOfPlays();
    }
}
