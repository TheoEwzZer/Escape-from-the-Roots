using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DropDownStory : MonoBehaviour
{
    public AudioClip intro;
    public AudioClip stage1;
    public AudioClip stage2;
    public AudioClip stage3;
    public AudioClip stage4;
    public AudioSource audioSource;
    public TextMeshProUGUI output;

    public void Start()
    {
        audioSource.clip = intro;
        audioSource.Play();
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MuteStory()
    {
        audioSource.mute = !audioSource.mute;
    }

    public void HandleInputData(int val)
    {
        if (val == 0) {
            audioSource.clip = intro;
            audioSource.Play();
            output.text = @"Your story takes place in the continent of Huldra, in a small village called Andromeda.You, Aegis, are acknowledged as the most skilled adventurer of this land.
            One day, searching for quests, you encounter an information officer. He informs you about the existence of a quest submitted by the Avalon, the Huldra adventurer's census institute.
            While reading the quest, you remember hearing about it a few days ago, by a terrified old man.
            He spoke about living trees coming from the forest near Huldra. After hearing that, you decide to accept the quest and check by your own.
            After a 5 day trip, you arrive safely at Huldra.  At your arrival, the city's mayor,  comes to greet you and asks if he can talk to you privately.
            You decide to follow him to his office to have a talk about the Avalon's quest.
            The mayor, looking paralyzed, after a deep breath kneels down and asks you a favor.";
        }
        if (val == 1) {
            audioSource.clip = stage1;
            audioSource.Play();
            output.text = @"On your way to achieve your quest, you encounter a decayed strange house that looks abandonned and decide to explore it.
            Right before closing the door behind you, you feel a menacing presence that forces you to step ahead and immediately look behind you.
            At the same time the door disappears and you have no choice left but to go forwards in the darkness.
            After walking for a while, you realize that the place structure looks like a maze's.
            And after walking for even longer, you start sounding root noises but you can't manage to locate them.
            Luckily, you manage to get far from these terrifying sounds and face a small strange wood statue.
            You decide to pick it up and to go back to where the weird sounds where coming from.
            When suddenly something grabs your arm tightly. By chance you manage to escape him and you run as fast as possible to escape the monster.
            While running you find 3 other wood statues that are alike the first one.
            You find yourself in a dead end, but fortunately, you notice a door with 4 empty spots for the statues you acquired earlier.
            As you hear the monster getting closer, you insert the statues in the empty spots and open the door to escape.";
        }
        if (val == 2) {
            audioSource.clip = stage2;
            audioSource.Play();
            output.text = @"As you step foot in the next room, your ears get coggled and your head aches.
            You decide to read the letter you received after collecting the last totem. And while reading it, you start to realize that the text contained in it strangely matches your adventure in the last room. 
            Even if you find it strange, you don't have time to be lost in your thoughts. Because you entered the second room.
            You figure out that the totems are the keys for getting to the next stage, so you start looking for them while being careful about the mysterious figures chasing you.
            After collecting a wood structure, you decide to name them 'totems' and focus on finding them as they saved your life in the previous room.
            From then, you have one objective to defeat the maze, collect all the totems. But how many are there ? 
            You'll have to overcome this monster roaming in this place filled with darkness to know it. 
            For now you don't have any clue of anything, but you know for a fact that you need to move away from these terrifying sounds from your right, at least if you want to survive.
            You barely started walking when you manage to find a landing lamp, rounded of blood. This tool might be the one you were searching for, as it might not be. 
            Considering the danger it represents, you still decide to switch it on, it is the only option to find the next totems. You continue walking around, looking for totems, when suddenly something dashes behind you, you immediately start running, and try desperately to survive.
            While running, your flashlight turns off, and so the noises disapear. When you raise your head up, you notice a door with four empty slots. You know the exit, and will manage to remember the pattern.
            Thanks to the flashlight you notice the mud completely covering the way, you decide to move on another path.
            You continue walking, still dodging traps, and avoiding the monster, you're developing new extra senses because of your incapacity of seing in the dark.
            So you manage to gather all the totems and escaping the second room.";
                    }
        if (val == 3) {
            audioSource.clip = stage3;
            audioSource.Play();
            output.text = @"You just escaped from three perilous mazes and arrive on a gigantic garden, from there you can see enormous branches, on which you can perceive various flowers and symbols.
            You start reading the letter you found at the previous stage :
                - 'Dear adventurer, if you're reading this, it means you defeated the third floor, and escaped the Kadambas. You must have noticed the previous letter was blank, it means that
                floors are not on watch. If you want to know more, try to catch up to me. For the time being let me tell you something. The next floor will require 10 totems, good luck ! '
            You didn't read the second letter, I hope you won't make the same mistakes...";
        }
        if (val == 4) {
            audioSource.clip = stage4;
            audioSource.Play();
            output.text = @"You’re now brought to a giant tree,  which produces a feeling of lightness inside your heart.
            You’re getting closer to it and enter the door.
            Once inside, you spot exactly what you’ve been fighting against since these few days. You manage to get one totem,  to avoid the Kadambas , and again more totems, then you reach the exit full of them.
            When you barely get outside, the maze starts disappearing and completely does in one second.
            You’re now arrived to your destination, you’re picking up a letter on which you can read :
            “I’ve now reached my destination, I’ve been exploring 149 floors since my arrival. I’ve been assisting many traumatic events, and I’m now writing this, in case it can reach someone, I need help, I can’t escape, no one can, even yourself. ”
            You’re feeling like you know him, but don’t know exactly why, it might be like you’re talking to yourself.
            Wait, who are you ?
            How, HOW IS THAT POSSIBLE,
            What’s happening
            WHO AM I";
        }
    }
}