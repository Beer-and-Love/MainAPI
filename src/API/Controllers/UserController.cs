﻿using API.Utilities;
using API.ViewModels;
using AutoMapper;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;
using Microsoft.AspNetCore.Cors;
namespace API.Controllers
{
   [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody]CreateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDto>(userViewModel);

                var userCreated = await _userService.Create(userDTO);

                return Ok( new ResultViewModel
                {
                    Success = true,
                    Data = userCreated,
                    Message = "Usuário Criado com Sucesso"
                });

            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


        [HttpPut]
        [Authorize]
        [Route("/api/v1/users/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel updateUserViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDto>(updateUserViewModel);
                var userUpdated = await _userService.Update(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário atualizado com sucesso!",
                    Success = true,
                    Data = userUpdated
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            { 
                return StatusCode(500,ex); 
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("/api/v1/users/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                var user = await _userService.Get(id);
                await _userService.Remove(id);
                if (user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário encontrado com o ID informado!",
                        Success = true,
                        Data = null
                    });
                }
                return Ok(new ResultViewModel
                {
                    Message = "Usuário removido com sucesso!",
                    Success = true,
                    Data = user
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var user = await _userService.Get(id);

                if (user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário encontrado com o ID informado!",
                        Success = true,
                        Data = user
                    });
                }
                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = user
                });
                    
               
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


        [HttpGet]
        // [Authorize]
        [Route("/api/v1/users/get-all")]
        [EnableCors]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allUsers = await _userService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Usuários encontrados com sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get-by-email")]
        public async Task<IActionResult> GetByEmailAsync([FromQuery] string email)
        {
            try
            {
                var user = await _userService.GetByEmail(email);
                
                if(user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário encontrado com o E-mail informado!",
                        Success = true,
                        Data = user
                    });
                }
                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = user
                });

            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/search-by-name")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var allUsers = await _userService.SearchByName(name);

                if(allUsers.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário encontrado com o Nome informado!",
                        Success = true,
                        Data = null
                    });
                }
                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }


        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/search-by-email")]
        public async Task<IActionResult> SearchByEmailAsync([FromQuery] string email)
        {
            try
            {
                var allUsers = await _userService.SearchByEmail(email);

                if (allUsers.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário encontrado com o E-mail informado!",
                        Success = true,
                        Data = null
                    });
                }
                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        // [Authorize]
        [Route("/api/v1/users/search-by-city")]
        public async Task<IActionResult> SearchByCityAsync([FromQuery] string city)
        {
            try
            {
                var allUsers = await _userService.SearchByCity(city);

                if (allUsers.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário encontrado com a cidade informada!",
                        Success = true,
                        Data = null
                    });
                }
                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }



    }
}