public class PromptGenerator
{
  private List<string> _prompts;

  public PromptGenerator()
  {
    _prompts = new List<string>()
        {
          "What small act of kindness did I witness or participate in today?",
          "What made me laugh today?",
          "What am I grateful for today?",
          "What challenged me today?",
          "What did I learn today?",
          "What surprised me today?",
          "What am I looking forward to tomorrow?",
          "What is one thing I can do to make tomorrow better?",
          "What is one thing I am proud of myself for today?",
          "What is one thing I will let go of today?",
          "How did I experience personal growth today?",
          "What limiting belief did I challenge today?",
          "What did I do for my physical and mental health today?",
          "How did I connect with others today?",
          "How did I express my creativity today?",
          "What did I do to nurture my relationships today?",
          "What brought me joy today?",
          "What caused me stress today, and how did I cope with it?",
          "What am I worried about, and what can I do to address it?",
          "Where did I see evidence of God's love today?",
          "How did I feel guided or supported by a higher power today?",
          "What spiritual lesson did I learn today?",
          "How did I contribute to something bigger than myself today?",
          "What am I praying for?",
          "Who was the most interesting person I interacted with today?",
          "What was the best part of my day?",
          "How did I see the hand of the Lord in my life today?",
          "What was the strongest emotion I felt today?",
          "If I had one thing I could do over today, what would it be?"
        };
  }

  public string GetRandomPrompt()
  {
    Random random = new Random();
    int index = random.Next(_prompts.Count);
    return _prompts[index];
  }
}