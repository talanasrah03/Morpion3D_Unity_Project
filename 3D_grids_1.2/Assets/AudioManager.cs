using UnityEngine;

 public class AudioManager : MonoBehaviour
    {
        private static AudioManager instance;
        public static AudioManager Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
