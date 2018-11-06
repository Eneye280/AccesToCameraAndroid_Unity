using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class ControlDeVoz : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keyworks = new Dictionary<string, System.Action>();

    private void Start()
    {
        keyworks.Add("photo", () =>
        {
            GoCalled();
        });

        keywordRecognizer = new KeywordRecognizer(keyworks.Keys.ToArray());
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizerOnPhrase;
		keywordRecognizer.Start();
    }
	private void KeywordRecognizerOnPhrase(PhraseRecognizedEventArgs args)
	{
		System.Action keyworksAction;

		if(keyworks.TryGetValue(args.text,out keyworksAction))
		{
			keyworksAction.Invoke();
		}
	}
    private void GoCalled()
    {
		print("Hola euclides ");
    }
}
