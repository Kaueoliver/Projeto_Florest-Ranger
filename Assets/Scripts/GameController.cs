using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameObject painelMenuPrincipal;
    [SerializeField] private GameObject painelOptions;
    [SerializeField] private GameObject painelPause;
    [SerializeField] private GameObject painelLevelSelect;
    

    
    public void StartGame(string lvlname) 
    {
        SceneManager.LoadScene(lvlname);
    }
    public void AbrirOptions() 
    {
        painelMenuPrincipal.SetActive(true);
        painelOptions.SetActive(true);

    }
    public void FecharOptions()
    {
        painelOptions.SetActive(false);
        painelMenuPrincipal.SetActive(true); 
    }
    public void SairJogo() 
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
    public void AbrirPause() 
    {
        painelPause.SetActive(true);
    }
    public void FecharPause() 
    {
        painelPause.SetActive(false);
    }
    public void MenuGame(string lvlname)
    {
        SceneManager.LoadScene(lvlname);
    }
    public void LevelSelect() 
    {
        painelLevelSelect.SetActive(true);
    }
    public void FecharLevelSelect()
    {
        painelLevelSelect.SetActive(false);
       
    }
    public void Reiniciar(string lvlname)
    {
        SceneManager.LoadScene(lvlname);
    }

}
