using app.clientesJipRodri.common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.clientesJipRodri.services.Interfaces
{
    public interface IClienteService
    {
        Task<BaseResponse<ClienteDTO>> Insertar(ClienteDTO clienteDTO);

        Task<BaseResponse<ClienteDTO>> SeleccionarUno(int id);

        Task<BaseResponse<List<ClienteDTO>>> SeleccionarTodos();

        Task<BaseResponse<ClienteDTO>> Actualizar(int id, ClienteDTO cliente);

        Task<BaseResponse<string>> Eliminar(int id);

    }
}
