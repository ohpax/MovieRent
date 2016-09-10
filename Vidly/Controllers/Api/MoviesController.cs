﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /Api/Movies
        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = _context.Movies
                .Include( m => m.Genre)
                .ToList()
                .Select( Mapper.Map<Movie, MovieDto>);

            return movies;
        }

        //Get /Api/Movies/id
        public MovieDto GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Movie, MovieDto>(movie);
        }

        //Post /api/Movies
        [HttpPost]
        [Authorize(Roles = RolesName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //Put /Api/Movies/id
        [HttpPut]
        [Authorize(Roles = RolesName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movieDto.Id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        //Delete /Api/Movies/id
        [HttpDelete]
        [Authorize(Roles = RolesName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}