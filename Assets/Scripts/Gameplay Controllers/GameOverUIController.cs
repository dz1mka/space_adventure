using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    public static GameOverUIController instance;

    [SerializeField] 
    private Canvas playerInfoCanvas, shipsAndMeteorsInfoCanvas, gameOverCanvas;

    [SerializeField]
    private Text shipsDestroyedFinalInfoTxt, meteorsDestroyedFinalInfoTxt, waveFinalInfoTxt;

    [SerializeField]
    private Text shipsDestroyedHighscoreTxt, meteorsDestroyedHighscoreTxt, waveHighscoreTxt;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void OpenGameOverPanel()
    {
        playerInfoCanvas.enabled = false;
        shipsAndMeteorsInfoCanvas.enabled = false;
        

        //playerInfoCanvas.enabled = shipsAndMeteorsInfoCanvas.enabled = false;
        gameOverCanvas.enabled = true;

        int shipsDestroyedFinal = GameplayUIController.Instance.GetShipsDestroyedCount();
        int meteorsDestroyedFinal = GameplayUIController.Instance.GetMeteorsDestroyedCount();
        int waveCountFinal = GameplayUIController.Instance.GetWaveCount();

        waveCountFinal--; // Decrease by 1 to get the last completed wave   

        shipsDestroyedFinalInfoTxt.text = "x" + shipsDestroyedFinal;
        meteorsDestroyedFinalInfoTxt.text = "x" + meteorsDestroyedFinal;
        waveFinalInfoTxt.text = "Wave: " + waveCountFinal;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(TagManager.GAMEPLAY_LEVEL_NAME);
    }

    public void MainMenu() 
    {
        SceneManager.LoadScene(TagManager.MAIN_MENU_LEVEL_NAME);
    }
}
