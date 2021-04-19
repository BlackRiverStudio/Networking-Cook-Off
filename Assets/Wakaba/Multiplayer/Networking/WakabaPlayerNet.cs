using Mirror;
using System.Collections;
using UnityEngine.SceneManagement;
using Wakaba.Multiplayer.UI;
namespace Wakaba.Multiplayer.Networking
{
    public class WakabaPlayerNet : NetworkBehaviour
    {
        [SyncVar] public byte playerId;
        [SyncVar] public string username = "";

        private Lobby lobby;
        private bool hasJoinedLobby = false;

        #region Commands
        [Command] public void CmdSetUsername(string _name) => username = _name;
        [Command] public void CmdAssignPlayerToLobbySlot(bool _left, int _slotId, byte _playerId) => RpcAssignPlayerToLobbySlot(_left, _slotId, _playerId);
        #endregion

        #region RPCs
        [ClientRpc] public void RpcAssignPlayerToLobbySlot(bool _left, int _slotId, byte _playerId)
        {
            // If this is running on the host client, ignore this call.
            if (WakabaNetworkManager.Instance.IsHost) return;

            // Find the lobby in the scene and set the player to the correct slot.
            StartCoroutine(AssignPlayerToLobbySlotDelayed(WakabaNetworkManager.Instance.GetPlayerForId(_playerId), _left, _slotId));
        }
        #endregion

        #region Coroutines
        private IEnumerator AssignPlayerToLobbySlotDelayed(WakabaPlayerNet _player, bool _left, int _slotId)
        {
            // Keep trying to get the lobby until it's not null.
            Lobby lobby = FindObjectOfType<Lobby>();
            while (lobby == null)
            {
                yield return null;
                lobby = FindObjectOfType<Lobby>();
            }

            // Lobby successfully got, so assign the player.
            lobby.AssignPlayerToLobbySlot(_player, _left, _slotId);
        }
        #endregion

        public void SetUsername(string _name)
        {
            // Only localPlayers can call Commands as localPlayers are the only ones who have the authority to talk to the server.
            if (isLocalPlayer) CmdSetUsername(_name);
        }

        public void AssignPlayerToSlot(bool _left, int _slotId, byte _playerId)
        {
            if (isLocalPlayer) CmdAssignPlayerToLobbySlot(_left, _slotId, _playerId);
        }

        private void Update()
        {
            // Determine if we are on the host client.
            if (WakabaNetworkManager.Instance.IsHost)
            {
                // Attempt to get the lobby if we haven't already joined the lobby.
                if (lobby == null && !hasAuthority) lobby = FindObjectOfType<Lobby>();

                // Attempt to join the lobby if we haven't already and the lobby is set.
                if (lobby != null && !hasAuthority)
                {
                    hasJoinedLobby = true;
                    lobby.OnPlayerConnected(this);
                }
            }
        }

        public override void OnStartClient() => WakabaNetworkManager.Instance.AddPlayer(this);

        // Runs only if the object is connected to the localPlayer.
        public override void OnStartLocalPlayer() => SceneManager.LoadSceneAsync("Lobby", LoadSceneMode.Additive);

        // Removes the playerId when the client is disconnected from the server.
        public override void OnStopClient() => WakabaNetworkManager.Instance.RemovePlayer(playerId);
    }
}