from gtts import gTTS
from io import BytesIO
from pydub import AudioSegment
from pydub.playback import play

class Speak():
    def __init__(self):
        return
    def doSpeak(self, sentence):
        mp3_fp = BytesIO()
        tts = gTTS(text = sentence, lang = 'zh-TW')
        tts.write_to_fp(mp3_fp)
        mp3_fp.seek(0)
        song = AudioSegment.from_file(mp3_fp)
        play(song)

        #song = AudioSegment.from_file(mp3_fp, format="mp3")
        #tts.save('test.mp3')
        return
