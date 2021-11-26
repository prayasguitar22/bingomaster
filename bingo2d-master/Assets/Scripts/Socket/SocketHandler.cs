using System;
using BestHTTP.SocketIO3;
using UnityEngine;

/*
 * SocketHandler class is responsible for connecting to socket using BestHTTP.SocketIO3
 * it is has singleton design pattern
 * the script is used in DoNotDestroy so that the socket connection persists on scene transitions
 * when connected to socket, this class consists of event listener functions which listens to the events emitted from server and act accordingly
 * listener functions do or call appropriate classes and methods to get things done
 */
namespace Socket
{
    public class SocketHandler : MonoBehaviour
    {
        private static SocketHandler _instance;
        /*
         * todo : create a toggle on Main Scene to choose between local-server or main-server
         * private const string URL = "https://kalobiralo.com/server/socket/socket.io/";
         */
        private const string URL = "http://127.0.0.1:8848/socket.io/";
        private const string Token = "someRandomToken";
        
        private SocketManager _manager;
        private SocketEmitter _emitter;

        private void Awake()
        {
            _instance = this;
        }

        public static SocketHandler GetInstance()
        {
            return _instance ? _instance : FindObjectOfType<SocketHandler>();
        }

        /*
         * todo : use real token later in production
         * this helps connecting to socket and creates event listener functions
         */
        private void Start()
        {
            var socketOptions = new SocketOptions {Auth = (manager, socket) => new {token = Token}};
            _manager = new SocketManager(new Uri(URL), socketOptions);
            
            _emitter = SocketEmitter.GetInstance();
            _emitter.Manager = _manager;
            
            _manager.Socket.On("connect", OnConnectedToSocket);
            _manager.Socket.On("err", OnErrorOccurred);
            _manager.Socket.On<LobbyInfo>("joinedLobby", OnJoinedLobby);
            _manager.Socket.On<RoomInfo>("joinedRoom", OnJoinedRoom);
            _manager.Socket.On("messageReceived", OnMessageReceived);
        }

        /*
         * on connected to socket, the function is called automatically
         * todo : remove login later on production, the server will handle login automatically on connection
         */
        private void OnConnectedToSocket()
        {
            Debug.Log("connected to socket");
            _emitter.Login(SystemInfo.deviceUniqueIdentifier);
        }
        
        /*
         * todo: handle error messages accordingly
         * error message are thrown by server when some emit actions fails
         */
        private void OnErrorOccurred()
        {
            Debug.Log("error occurred");
        }

        /*
         * todo : remove later on, connection will automatically add player to lobby and return on OnConnectedToSocket or OnErrorOccurred
         */
        private void OnJoinedLobby(LobbyInfo lobby)
        {
            Debug.Log("joined Lobby : " + lobby.userId);
        }

        /*
         * when player joins the room, and when roomInfo is changed, the function is executed
         * todo : update UI if waiting for game to start. update playerStatus if on GameScene
         */
        private void OnJoinedRoom(RoomInfo roomInfo)
        {
            Debug.Log("joined room : " + roomInfo.roomName);
        }

        /*
         * a simple callback, can later be change accordingly for some purpose
         */
        private void OnMessageReceived()
        {
            Debug.Log("message received");
        }
    }

    // format in which lobby info is received
    internal class LobbyInfo
    {
        public String userId;
    }

    // format in which roomInfo is received
    internal class RoomInfo
    {
        public string roomName;
        public string[] players;
        public bool isPublic;
        public bool isOpen;
        public bool isFull;
        public bool gameStarted;
    }
}
