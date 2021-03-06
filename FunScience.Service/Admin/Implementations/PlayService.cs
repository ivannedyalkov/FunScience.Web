﻿namespace FunScience.Service.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using FunScience.Data;
    using FunScience.Data.Models;
    using FunScience.Service.Admin.Models.Play;
    using FunScience.Service.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayService : IPlayService
    {
        private readonly FunScienceDbContext db;

        public PlayService(FunScienceDbContext db)
        {
            this.db = db;
        }

        public bool AddPlay(string name)
        {
            if (this.db.Plays.Any(p => p.Name == name))
            {
                return false;
            }

            var play = new Play
            {
                Name = name
            };

            this.db.Plays.Add(play);

            this.db.SaveChanges();

            return true;
        }

        public bool Edit(int id, string name)
        {
            var play = this.db
                .Plays
                .FirstOrDefault(p => p.Id == id);

            if (play == null)
            {
                throw new ArgumentNullException(ErrorConstants.PlayDoesNotЕxist);
            }

            if (play.Name != name && this.db.Plays.Any(p => p.Name == name && p.Id != id))
            {
                return false;
            }

            play.Name = name;
            
            this.db.SaveChanges();

            return true;
        }

        public PlayListingModel PlayInfo(int id)
        {
            var play = this.db
                .Plays
                .ProjectTo<PlayListingModel>()
                .FirstOrDefault(p => p.Id == id);

            if (play == null)
            {
                throw new ArgumentNullException(ErrorConstants.PlayDoesNotЕxist);
            }

            return play;
        }

        public void Delete(int id)
        {
            var play = this.db.Plays.Find(id);

            if (play == null)
            {
                throw new ArgumentNullException(ErrorConstants.PlayDoesNotЕxist);
            }

            this.db.Plays.Remove(play);

            this.db.SaveChanges();
        }

        public IEnumerable<PlayListingModel> ListOfPlays()
        {
            return this.db
                .Plays
                .ProjectTo<PlayListingModel>()
                .OrderBy(s => s.Name)
                .ToList();
        }
    }
}

