using EtfragApp.BLL.DTOs.Episode;
using EtfragApp.BLL.DTOs.Pages;
using EtfragApp.BLL.DTOs.TVSeries;
using EtfragApp.BLL.FileManagement;
using EtfragApp.BLL.Interfaces;
using EtfragApp.BLL.ServicesContracts;
using EtfragApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.Sevices
{
    public class TVSeriesService : ITVSeriesService
    {
        public IUnitOfWork _unitOfWork;
        public TVSeriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTVSeries(CreateTVSeriesDto tvSeriesDto)
        {

            TVSeries tVSeries = new TVSeries
            {
                Description = tvSeriesDto.Description,
                AgeRating = tvSeriesDto.AgeRating,
                CountryOfOrigin = tvSeriesDto.CountryOfOrigin,
                DirectorName = tvSeriesDto.DirectorName,
                Quality = tvSeriesDto.Quality,
                ReleasYear = tvSeriesDto.ReleasYear,
                Title = tvSeriesDto.Title,

                ThumbnailImageUrl = DocumentsSettings.UploadFile(tvSeriesDto.ThumbnailImage, "Posters"),
                CoverImageUrl = DocumentsSettings.UploadFile(tvSeriesDto.CoverImage, "Covers"),
            };


            var tvSeriesEpisodes = tvSeriesDto.Episodes.Select((ep, index) => new Episode
            {
                EpisodeURL = DocumentsSettings.UploadFile(ep, "Videos"),
                EpisodeNumber = index + 1,
            }).ToList();

            tVSeries.Episodes = tvSeriesEpisodes;

            var tvSeriesActors = tvSeriesDto.ActorIDs.Select(actorID => new TVSeriesActor
            {
                ActorId = actorID,
            }).ToList();

            tVSeries.TVSeriesActors = tvSeriesActors;

            var tvSeriesCategories = tvSeriesDto.CategoriesIDs.Select(categoryID => new TVSeriesCategory
            {
                CategoryId = categoryID,
            }).ToList();

            tVSeries.TVSeriesCategories = tvSeriesCategories;

            _unitOfWork.TVSeriesRepository.AddEntity(tVSeries);
            _unitOfWork.Save();
        }



        public void Delete(int id)
        {
            _unitOfWork.TVSeriesRepository.DeleteEntity(id);
            _unitOfWork.Save();
        }

        public IEnumerable<TVSeriesDto> GetAll()
        {
            IEnumerable<TVSeries> series = _unitOfWork.TVSeriesRepository.GetAll();

            return series.Select(s => new TVSeriesDto
            {
                Id = s.Id,
                AgeRating = s.AgeRating,
                AddedAt = s.AddedAt,
                CountryOfOrigin = s.CountryOfOrigin,
                Title = s.Title,
                IsFeatured = s.IsFeatured,
            });
        }

        public IEnumerable<TVSeriesDto> GetAllDesc()
        {
            throw new NotImplementedException();
        }

        public TVSeriesDto GetById(int id)
        {

            TVSeries series = _unitOfWork.TVSeriesRepository.GetEntityAndRelatsById(id, s => s.Episodes, s => s.TVSeriesActors, s => s.TVSeriesCategories);

            return new TVSeriesDto
            {
                Id = series.Id,
                AgeRating = series.AgeRating,
                AddedAt = series.AddedAt,
                CountryOfOrigin = series.CountryOfOrigin,
                Title = series.Title,
                CoverImageUrl = series.CoverImageUrl,
                ThumbnailImageUrl = series.ThumbnailImageUrl,
                Description = series.Description,
                DirectorName = series.DirectorName,
                Episodes = series.Episodes.Select(e => new EpisodeDto { EpisodeURL = e.EpisodeURL, Id = e.EpisodeId, Duration = e.Duration }).ToList(),
            };
        }

        public IEnumerable<TVSeriesDto> GetSpecificNumOfRecordsDescending(int num)
        {
            var series = _unitOfWork.TVSeriesRepository.GetSpecificNumOfRecordsDescending(num);

            return series.Select(s => new TVSeriesDto
            {
                Id = s.Id,
                Title = s.Title,
                AddedAt = s.AddedAt
            }
            );
        }


        public void Update(EditTVSeriesDto tvSeriesDto)
        {
            //_unitOfWork.TVSeriesRepository.UpdateEntity(tvSeries);
            _unitOfWork.Save();
        }
        public void TogglePopularity(int id)
        {
            TVSeries tvSeries = _unitOfWork.TVSeriesRepository.GetEntityById(id);
            tvSeries.IsFeatured = !tvSeries.IsFeatured;
            _unitOfWork.TVSeriesRepository.UpdateEntity(tvSeries);
            _unitOfWork.Save();
        }

        public DetailsTVSeriesDto GetTVSeriesDetails(int id, int episodeNum)
        {
            var tvSeries = _unitOfWork.TVSeriesRepository.GetEntityAndRelatsById(id, m => m.TVSeriesCategories, m => m.Episodes);

            List<string> categories = _unitOfWork.TVSeriesRepository.GetMovieCategoriesName(id);

            return new DetailsTVSeriesDto
            {
                Title = tvSeries.Title,
                CoverImageUrl = tvSeries.CoverImageUrl,
                Description = tvSeries.Description,
                AgeRating = tvSeries.AgeRating,
                Quality = tvSeries.Quality,
                ReleasYear = tvSeries.ReleasYear,
                categories = categories,
                EpisodeNum = episodeNum,
                Episodies = tvSeries.Episodes.Select(episode => new EpisodeDto
                {
                    Duration = episode.Duration,
                    EpisodeURL = episode.EpisodeURL,
                    Id = episode.EpisodeId,

                }).ToList()
            };
        }


        public PageData<TVSeriesDto> Getpage(int pageSize, int pageNo, bool needCount)
        {
            int? totalCount;
            var series = _unitOfWork.TVSeriesRepository.Getpage(pageSize, pageNo, out totalCount, needCount);

            return new PageData<TVSeriesDto>
            {
                Data = series.Select(mov => new TVSeriesDto
                {
                    Id = mov.Id,
                    ThumbnailImageUrl = mov.ThumbnailImageUrl,
                    Title = mov.Title,
                    AgeRating = mov.AgeRating,
                    CountryOfOrigin = mov.CountryOfOrigin,
                    CoverImageUrl = mov.CoverImageUrl,
                    Description = mov.Description,
                    DirectorName = mov.DirectorName,
                    Quality = mov.Quality,
                    ReleasYear = mov.ReleasYear,
                    AddedAt = mov.AddedAt,
                    IsFeatured = mov.IsFeatured,

                }).ToList(),
                TotalRecords = totalCount
            };
        }

        public PageData<TVSeriesDto> GetPageWithSearch(int pageSize, int pageNo, bool needCount, string searchName)
        {
            int? totalCount;
            var series = _unitOfWork.TVSeriesRepository.GetPageWithSearch(pageSize, pageNo, out totalCount, needCount, searchName);

            return new PageData<TVSeriesDto>
            {
                Data = series.Select(mov => new TVSeriesDto
                {
                    Id = mov.Id,
                    ThumbnailImageUrl = mov.ThumbnailImageUrl,
                    Title = mov.Title,
                    AgeRating = mov.AgeRating,
                    CountryOfOrigin = mov.CountryOfOrigin,
                    CoverImageUrl = mov.CoverImageUrl,
                    Description = mov.Description,
                    DirectorName = mov.DirectorName,
                    Quality = mov.Quality,
                    ReleasYear = mov.ReleasYear,
                    AddedAt = mov.AddedAt,
                    IsFeatured = mov.IsFeatured,

                }).ToList(),
                TotalRecords = totalCount
            };
        }
    }
}
