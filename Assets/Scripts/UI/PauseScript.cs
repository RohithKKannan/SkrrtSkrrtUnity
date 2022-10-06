using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject ControlsPanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject ConfirmPanel;
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject CrossButton;
    void Start()
    {
        if (masterControl.touchActive == false)
            ControlsPanel.SetActive(true);
    }
    public void PauseClicked()
    {
        //Pause time
        Time.timeScale = 0;

        //Activate Pause Panel
        PausePanel.SetActive(true);
        //Deactivate Pause Button
        PauseButton.SetActive(false);
        CrossButton.SetActive(true);
        //Deactivate Controls Panel
        if (ControlsPanel.activeInHierarchy)
            ControlsPanel.SetActive(false);
    }

    public void ResumeClicked()
    {
        //Resume time
        Time.timeScale = 1;

        //Deactivate Pause Panel
        PausePanel.SetActive(false);
        //Activate Pause Button
        PauseButton.SetActive(true);
        CrossButton.SetActive(false);
        if (ConfirmPanel.activeInHierarchy)
            ConfirmPanel.SetActive(false);
        if (SettingsPanel.activeInHierarchy)
            SettingsPanel.SetActive(false);
        //Activate Controls Panel
        if (!ControlsPanel.activeInHierarchy && masterControl.touchActive == false)
            ControlsPanel.SetActive(true);
    }

    public void ExitClicked()
    {
        ConfirmPanel.SetActive(true);
    }

    public void ConfirmYes()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("touchScene");
    }

    public void ConfirmNo()
    {
        ConfirmPanel.SetActive(false);
    }

    public void SettingsClicked()
    {
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    public void GoBack()
    {
        PausePanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
}
