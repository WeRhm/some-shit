using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.UI;

public class OnSwipeChangeText : MonoBehaviour {

	[SerializeField] private VRInput m_Input;
	[SerializeField] private VRInteractiveItem m_InteractiveItem;

	private bool m_GazeOver;

	private string[] pages;
	private int index = 0;

	private UnityEngine.UI.Text textView;

	private void OnEnable ()
	{
		GameObject displayText = GameObject.FindGameObjectWithTag ("text-ui");
		textView = displayText.GetComponentInChildren<UnityEngine.UI.Text> ();
		initPages ();
		m_Input.OnSwipe += OnSwipe;

		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
	}

	private void HandleOver ()
	{
		m_GazeOver = true;
	}


	private void HandleOut ()
	{
		m_GazeOver = false;
	}

	private void OnSwipe(VRInput.SwipeDirection swipe) {
		if (m_GazeOver) {
			if (swipe == VRInput.SwipeDirection.LEFT) {
				changeTextToNext();
			} else if (swipe == VRInput.SwipeDirection.RIGHT) {
				changeTextToPrev();
			}
		}
	}

	private void changeTextToNext() {
		increment();
		textView.text = pages[index];
	}

	private void changeTextToPrev() {
		decrement();
		textView.text = pages[index];
	}

	private void initPages () {
		pages = new string[4];
		pages[0] = "<size=16>Social X Factor\n<b>Speak Up!</b></size>\n\n<size=13s><color=cyan>1.Problem</color></size>\nMenschen, die sich in ihrem Vortrag verhaspeln, " +
			"stottern oder viel zu leise sprechen - das ist ein bekanntes Phänomen in fast jedem Bereich, in dem Präsentationen ohne professionelle " +
			"Ausbildung abgehalten werden.\nAllerdings ist das selbstbewusste Auftreten und Präsentationskompetenz heutzutage unententbehrlich.";
		pages[1] = "Schon in der Ausbildung muss man viele mündliche Prüfungen in unterschiedlichster Form ablegen.\nIn Amerika allerdings, " +
			"gehört die Angst, vor Publikum zu reden, auch <i>\"Pulic Speaking\"</i> gennant, beispielsweise zur Amgst Nummer eins (vgl. Statistic Brain 2013; " +
			"vgl. Croston 2012).\nAuch in einer von uns durchgeführten, quantitativen Erhebung haben 82% der Befragten aller Altersstufen angegeben, " +
			"dass sie in den vergangenen zwölf Monaten jemanden mit Übungsbedarf präsentieren gesehen haben.";
		pages[2] = "Allerdings gibt es bisher nur begrenzte Möglichkeiten diese Kompetenz außerhalb der Bewertungssituation zu trainieren.\n\n" +
			"<size=13><color=cyan>2.Lösung</color></size>\nDiese Furcht vor öffentlichen Reden oder bewerteten Präsentationen und der Stellenwert des freien Sprechens " +
			"sind die Ausgangslage unseres Projekts:\nwir entwickeln eine App, die mithilfe von <i>\"Virtueller Realität\"</i> die Menschen an \"Pulic Speaking\" gewöhnt " +
			"und ihnen so die Angst nimmt.";
		pages[3] = "THE END";

		textView.text = pages[index];
	}

	private void increment() {
		if (index < pages.Length-1)
			index++;
	}

	private void decrement(){
		if (index > 0)
			index--;
	}
}