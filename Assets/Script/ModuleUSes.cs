using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.U2D;

namespace UnityEngine.Rendering.Universal
{
    public class ModuleUSes : MonoBehaviour
    {
        public string type;
        public string name;
        public GameObject[] turret;
        public AudioClip[] sounds;
        public Light2D[] lights;
        public bool shield;
        public bool extractor;
        bool cahnge =true;
        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            if (cahnge)
            {
                StartCoroutine(Disco());
            }
        }
        IEnumerator Disco()
        {
            cahnge = false;
            foreach(Light2D light2D in lights)
            {
                light2D.color = new Color(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
            }
            yield return new WaitForSeconds(0.5f);
            cahnge = true;
        }
    }
}
