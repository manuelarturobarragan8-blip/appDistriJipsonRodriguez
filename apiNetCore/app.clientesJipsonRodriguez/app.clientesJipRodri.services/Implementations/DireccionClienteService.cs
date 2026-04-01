using app.clientesJipRodri.common.DTOs;
using app.clientesJipRodri.dataAccess.repositories;
using app.clientesJipRodri.entities.models;
using app.clientesJipRodri.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.clientesJipRodri.services.Implementations
{
    public class DireccionClienteService : IDireccionClienteService
    {
        private readonly IDireccionClienteRepository _repository;

        public DireccionClienteService(IDireccionClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<DireccionClienteDTO>> Insertar(DireccionClienteDTO dto)
        {
            var response = new BaseResponse<DireccionClienteDTO>();
            try
            {
                DireccionCliente entity = new()
                {
                    ClienteId = dto.ClienteId,
                    Provincia = dto.Provincia,
                    Ciudad = dto.Ciudad,
                    Direccion = dto.Direccion,
                    CodigoPostal = dto.CodigoPostal,
                    Estado = true,
                    Fecha = DateTime.Now
                };

                entity = await _repository.Insertar(entity);

                dto.Id = entity.Id;
                response.Result = dto;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<DireccionClienteDTO>> SeleccionarUno(int id)
        {
            var response = new BaseResponse<DireccionClienteDTO>();

            try
            {
                var entity = await _repository.SeleccionarUno(id);

                if (entity == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Dirección no encontrada";
                    return response;
                }

                response.Result = new DireccionClienteDTO
                {
                    Id = entity.Id,
                    ClienteId = entity.ClienteId,
                    Provincia = entity.Provincia,
                    Ciudad = entity.Ciudad,
                    Direccion = entity.Direccion,
                    CodigoPostal = entity.CodigoPostal,
                    Estado = entity.Estado
                };

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<List<DireccionClienteDTO>>> SeleccionarTodos()
        {
            var response = new BaseResponse<List<DireccionClienteDTO>>();

            try
            {
                var list = await _repository.SeleccionarTodos();

                response.Result = list.Select(d => new DireccionClienteDTO
                {
                    Id = d.Id,
                    ClienteId = d.ClienteId,
                    Provincia = d.Provincia,
                    Ciudad = d.Ciudad,
                    Direccion = d.Direccion,
                    CodigoPostal = d.CodigoPostal,
                    Estado = d.Estado
                }).ToList();

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<DireccionClienteDTO>> Actualizar(int id, DireccionClienteDTO dto)
        {
            var response = new BaseResponse<DireccionClienteDTO>();

            try
            {
                DireccionCliente entity = new()
                {
                    Id = id,
                    ClienteId = dto.ClienteId,
                    Provincia = dto.Provincia,
                    Ciudad = dto.Ciudad,
                    Direccion = dto.Direccion,
                    CodigoPostal = dto.CodigoPostal,
                    Estado = true,
                    Fecha = DateTime.Now
                };

                await _repository.Actualizar(entity);

                dto.Id = id;
                response.Result = dto;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<string>> Eliminar(int id)
        {
            var response = new BaseResponse<string>();

            try
            {
                await _repository.Eliminar(id);

                response.Result = "OK";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}
