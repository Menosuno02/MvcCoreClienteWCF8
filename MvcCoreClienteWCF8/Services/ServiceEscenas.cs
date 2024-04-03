using ServiceReferenceEscenas;

namespace MvcCoreClienteWCF8.Services
{
    public class ServiceEscenas
    {
        EscenasContractClient client;

        public ServiceEscenas(EscenasContractClient client)
        {
            this.client = client;
        }

        public async Task<EscenaPelicula[]> GetEscenasAsync()
        {
            EscenaPelicula[] escenas = await this.client.GetEscenasAsync();
            return escenas;
        }

        public async Task<EscenaPelicula[]> GetEscenasPeliculaAsync
            (int idpelicula)
        {
            EscenaPelicula[] escenas = await this.client.GetEscenasPeliculaAsync(idpelicula);
            return escenas;
        }
    }
}
