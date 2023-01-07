using Microsoft.AspNetCore.SignalR;

namespace EducaciontItSabados
{
	public class ChatHub : Hub
	{
		public async Task EnviarMensaje(int room, string usuario, string mensaje)
		{
			await Clients.Group(room.ToString()).SendAsync("RecibirMensaje", usuario, mensaje);
		}

		public async Task AgregarAlGrupo(string room)
		{
			await Groups.AddToGroupAsync(Context.ConnectionId, room);
		}
	}
}
