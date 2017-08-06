using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SongGenerator : MonoBehaviour {

    public TextAsset file;

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

        NoteData noteData = new NoteData();
        noteData.bars = new List<List<Note>>();

        var lines = file.text.Split("\n"[0]);
        for (int i = 0; i < lines.Length; ++i)
        {
            var line = lines[i];
        }
    }


    private NoteData ParseNotes(List<string> notes)
    {
        NoteData noteData = new NoteData();
        noteData.bars = new List<List<Note>>();

        //And then work through each line of the raw note data
        List<string> bars = new List<string>();
        for (int i = 0; i < notes.Count; i++)
        {
            //Based on different line properties we can determine what data that
            //line contains, such as a semicolon dictating the end of the note data
            //or a comma indicating the end of that bar
            string line = notes[i].Trim();

            if (line.StartsWith(";"))
            {
                break;
            }

            if (line.EndsWith(","))
            {
                noteData.bars.Add(bar);
                bar = new List();
            }
            else if (line.EndsWith(":"))
            {
                continue;
            }
            else if (line.Length & gt;= 4)
            {
                //When we have a single 'note row' such as '0010' or '0110'
                //We check which columns will contain 'steps' and mark the appropriate flags
                Notes note = new Notes();
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

                //We then add this information to our current bar and continue until end
                bar.Add(note);
            }
        }

        return noteData;
    }

    void Update () {
		
	}
}
