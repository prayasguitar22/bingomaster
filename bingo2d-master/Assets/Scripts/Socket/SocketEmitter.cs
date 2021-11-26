using BestHTTP.SocketIO3;
using UnityEngine;

/*
 * this class is used to emit events from client to server
 * it consists of public static Methods that can be called from any other place in code
 */
namespace Socket
{
    public class SocketEmitter : MonoBehaviour
    {
        private static SocketEmitter instance;
        public SocketManager Manager;

        private void Awake()
        {
            instance = this;
        }

        public static SocketEmitter GetInstance()
        {
            return instance ? instance : FindObjectOfType<SocketEmitter>();
        }

        /*
         * call this method when needed to login
         */
        public void Login(string userId)
        {
            Manager.Socket.Emit("login", userId);
        }

        /*
         * call this method for joining public room
         */
        public void PlayPublic()
        {
            var data = new PublicRoomJoinData {type = "public"};
            var dataToSend = JsonUtility.ToJson(data);
            Manager.Socket.Emit("joinRoom", dataToSend);
        }
    }

    // data format to connect to public room
    internal class PublicRoomJoinData
    {
        public string type;
    }
}
