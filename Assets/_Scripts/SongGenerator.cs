using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SongGenerator : MonoBehaviour {

    public TextAsset file;
    public GameObject noteObject;

    public Transform[] noteLines;
    public GameObject[] gg;


    public struct Metadata
    {
        //Is the song's structure valid?
        public bool valid;

        //The Title, Subtitle and Artist for the song
        public string title;
        public string subtitle;
        public string artist;

        //The file paths for the related images and song media
        public string bannerPath;
        public string backgroundPath;
        public string musicPath;

        //The offset that the song starts at compared to the step info
        public float offset;

        //The start and length of the sample that is played when selecting a song
        public float sampleStart;
        public float sampleLength;

        //The bpm the song is played at
        public float bpm;

        //The note data for each difficulty, 
        //as well as a boolean to check that data for that difficulty exists
        public NoteData beginner;
        public bool beginnerExists;
        public NoteData easy;
        public bool easyExists;
        public NoteData medium;
        public bool mediumExists;
        public NoteData hard;
        public bool hardExists;
        public NoteData challenge;
        public bool challengeExists;
    }

    public struct NoteData
    {
        public List<List<Note>> bars;
    }

    public struct Note
    {
        public bool left;
        public bool right;
        public bool up;
        public bool down;
    }

    void Start() {
        bool inNotes = false;

        Metadata songData = new Metadata();

        songData.valid = true;
        songData.beginnerExists = false;
        songData.easyExists = false;
        songData.mediumExists = false;
        songData.hardExists = false;
        songData.challengeExists = false;

        NoteData noteData;

        var lines = file.text.Split("\n"[0]);

        noteData = ParseNotes(lines);

        StartCoroutine(SpawnNotes(noteData));
    }


    private NoteData ParseNotes(string[] notes)
    {
        print("Start Parse");
        NoteData noteData = new NoteData();
        noteData.bars = new List<List<Note>>();

        List<Note> bar = new List<Note>();
        for (int i = 0; i < notes.Length; i++)
        {
            string line = notes[i].Trim();

            if (line.StartsWith(";"))
            {
                break;
            }

            if (line.EndsWith(","))
            {
                noteData.bars.Add(bar);
                bar = new List<Note>();
            }
            else if (line.EndsWith(":"))
            {
                continue;
            }
            else if (line.Length <= 4)
            {
                Note note = new Note();
                note.left = false;
                note.down = false;
                note.up = false;
                note.right = false;


                if (line[0] != '0')
                {
                    note.left = true;
                }
                if (line[1] != '0')
                {
                    note.down = true;
                }
                if (line[2] != '0')
                {
                    note.up = true;
                }
                if (line[3] != '0')
                {
                    note.right = true;
                }

                bar.Add(note);
            }
        }
        print("End Parse");
        return noteData;
    }

    IEnumerator SpawnNotes(NoteData data)
    {
        float bpm = 108.650f;

        for (int i = 0; i < data.bars.Count; ++i)
        {
            for(int j = 0; j < data.bars[i].Count; ++j)
            {
                if (data.bars[i][j].left)
                {
                    Instantiate(noteObject, noteLines[0].position, Quaternion.identity);
                    StartCoroutine(gg[0].GetComponent<Activator>().Pressed());
                }
                if (data.bars[i][j].up)
                {
                    Instantiate(noteObject, noteLines[1].position, Quaternion.identity);
                    StartCoroutine(gg[1].GetComponent<Activator>().Pressed());
                }
                if (data.bars[i][j].down)
                {
                    Instantiate(noteObject, noteLines[2].position, Quaternion.identity);
                    StartCoroutine(gg[2].GetComponent<Activator>().Pressed());
                }
                if (data.bars[i][j].right)
                {
                    Instantiate(noteObject, noteLines[3].position, Quaternion.identity);
                    StartCoroutine(gg[3].GetComponent<Activator>().Pressed());
                }

                yield return new WaitForSeconds(60/bpm - Time.deltaTime);

            }
        }
    }

    void Update () {
		
	}
}
