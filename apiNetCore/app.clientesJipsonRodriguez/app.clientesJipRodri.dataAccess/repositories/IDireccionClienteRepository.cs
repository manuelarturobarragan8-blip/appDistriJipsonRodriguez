using app.clientesJipRodri.entities.models;

namespace app.clientesJipRodri.dataAccess.repositories
{
    public interface IDireccionClienteRepository
    {
        Task<DireccionCliente> SeleccionarUno(int id);

        Task<DireccionCliente> Insertar(DireccionCliente direccionCliente);

        Task<List<DireccionCliente>> SeleccionarTodos();

        Task Actualizar(DireccionCliente direccionCliente);

        Task Eliminar(int id);
    }
}