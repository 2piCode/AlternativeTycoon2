using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Game 
{
    public class ProjectNote : MonoBehaviour
    {
        [SerializeField] private GameObject projectNoteCanvas;
        [SerializeField] private Text leftPage;
        [SerializeField] private Text rightPage;

        [SerializeField] private Button nextSpreadButton;
        [SerializeField] private Button prevSpreadButton;
        [SerializeField] private Button closeButton;
        [SerializeField] private Text spreadNumber;
        public int amountOfSpreads => pages.Count / 2 + Convert.ToInt32(pages.Count % 2 != 0);
        private List<string> pages = new List<string>();
        public int currentSpread { get; private set; }

        private void Awake()
        {
            nextSpreadButton.onClick.AddListener(TurnToNextSpread);
            prevSpreadButton.onClick.AddListener(TurnToPrevSpread);
            closeButton.onClick.AddListener(() => projectNoteCanvas.SetActive(false));
        }

        private void Start()
        {
            //GameManager.singleton.onFinishDay += writeAchievmentsInNote;
            projectNoteCanvas.SetActive(false);
            currentSpread = 0;
            nextSpreadButton.interactable = false;
            prevSpreadButton.interactable = false;
            foreach (var achievment in GameManager.singleton.Achievments.Values)
            {
                achievment.onPassAchievment += WriteAchievmentsInNote;
            }
        }
        
        private void OnMouseDown() => projectNoteCanvas.SetActive(true);

        // update info in spread
        private void SetSpread()
        {
            leftPage.text = pages[currentSpread * 2];
            rightPage.text = pages.Count - currentSpread * 2 == 1 ? 
                string.Empty : pages[currentSpread * 2 + 1];

            spreadNumber.text = $"{currentSpread + 1}/{amountOfSpreads}";
            prevSpreadButton.interactable = (currentSpread != 0);
            nextSpreadButton.interactable = (currentSpread + 1 != amountOfSpreads);
        }
        public void TurnToNextSpread()
        {
            if (currentSpread + 1 > amountOfSpreads) return;
            currentSpread++;
            SetSpread();
        }

        public void TurnToPrevSpread()
        {
            if (currentSpread - 1 < 0) return;
            currentSpread--;
            SetSpread();
        }

        private void WriteTextInNote(string text)
        {
            TextGenerationSettings settings = leftPage.GetGenerationSettings(leftPage.rectTransform.rect.size);
            TextGenerator textGenerator = new TextGenerator();
            int index = 0;

            Debug.Log(text);
            if (pages.Count != 0)
            {
                text = pages[pages.Count - 1] + text;
                pages.RemoveAt(pages.Count - 1);
            }

            while (text.Length != 0)
            {
                textGenerator.Populate(text, settings);
                index = textGenerator.characterCountVisible;
                pages.Add(text.Substring(0, index));
                text = text.Substring(index).Trim();
            }
            SetSpread();
        }

        private void WriteAchievmentsInNote(Achievment achievment)
        {
            string achievmentText = $"{achievment.name}\n{achievment.description}\n\n";
            WriteTextInNote(achievmentText);
        }
    }
}