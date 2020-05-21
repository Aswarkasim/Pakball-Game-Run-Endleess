using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//load library scene manager
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour {

    //inisialisasi variabel
    public AudioSource ButtonSound;
    public string namaScene;
    GameManager GameManager;

    void Start () {

	}

    public void PindaKeScene(){

        AudioSource buttonSound = ButtonSound.GetComponent<AudioSource>();
        buttonSound.PlayOneShot(buttonSound.clip);

    //Pinda scene
    //cek sccene
    Scene sceneIni =  SceneManager.GetActiveScene();

        if(sceneIni.name != namaScene){
            SceneManager.LoadScene(namaScene);
        }
    }

    public void exit(){
        Application.Quit();
    }

}
