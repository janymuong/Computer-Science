% ICS 2308 Artificial Intelligence - Anime Knowledge Base in Prolog
% A KB for analyzing, categorizing, and recommending anime

% Group 7
% SCT211-0848/2018 - Jany Muong
% A KB for analyzing, categorizing, and recommending anime
% A KB for analyzing, categorizing, and recommending anime
% A KB for analyzing, categorizing, and recommending anime

% ==========================================
% PART 1: ANIME FUNDAMENTALS
% ==========================================

% Basic anime information - anime(Title, Studio, Director, ReleaseYear, Episodes)
anime('Fullmetal Alchemist: Brotherhood', 'Bones', 'Yasuhiro Irie', 2009, 64).
anime('Death Note', 'Madhouse', 'Tetsuro Araki', 2006, 37).
anime('Attack on Titan', 'Wit Studio', 'Tetsuro Araki', 2013, 87).
anime('Steins;Gate', 'White Fox', 'Hiroshi Hamasaki', 2011, 24).
anime('One Punch Man', 'Madhouse', 'Shingo Natsume', 2015, 12).
anime('My Hero Academia', 'Bones', 'Kenji Nagasaki', 2016, 113).
anime('Demon Slayer', 'Ufotable', 'Haruo Sotozaki', 2019, 26).
anime('Violet Evergarden', 'Kyoto Animation', 'Taichi Ishidate', 2018, 13).
anime('Cowboy Bebop', 'Sunrise', 'Shinichiro Watanabe', 1998, 26).
anime('Naruto', 'Pierrot', 'Hayato Date', 2002, 220).
anime('One Piece', 'Toei Animation', 'Konosuke Uda', 1999, 1000).
anime('Hunter x Hunter', 'Madhouse', 'Hiroshi Koujina', 2011, 148).
anime('Neon Genesis Evangelion', 'Gainax', 'Hideaki Anno', 1995, 26).
anime('Your Lie in April', 'A-1 Pictures', 'Kyohei Ishiguro', 2014, 22).
anime('Spirited Away', 'Studio Ghibli', 'Hayao Miyazaki', 2001, 1).
anime('Princess Mononoke', 'Studio Ghibli', 'Hayao Miyazaki', 1997, 1).
anime('Jujutsu Kaisen', 'MAPPA', 'Sunghoo Park', 2020, 24).
anime('Vinland Saga', 'Wit Studio', 'Shuhei Yabuta', 2019, 24).
anime('Monster', 'Madhouse', 'Masayuki Kojima', 2004, 74).
anime('Berserk', 'OLM', 'Naohito Takahashi', 1997, 25).

% Genres
genre('Fullmetal Alchemist: Brotherhood', 'Action').
genre('Fullmetal Alchemist: Brotherhood', 'Adventure').
genre('Fullmetal Alchemist: Brotherhood', 'Fantasy').
genre('Death Note', 'Mystery').
genre('Death Note', 'Psychological').
genre('Death Note', 'Supernatural').
genre('Attack on Titan', 'Action').
genre('Attack on Titan', 'Dark Fantasy').
genre('Attack on Titan', 'Post-Apocalyptic').
genre('Steins;Gate', 'Sci-Fi').
genre('Steins;Gate', 'Thriller').
genre('Steins;Gate', 'Time Travel').
genre('One Punch Man', 'Action').
genre('One Punch Man', 'Comedy').
genre('One Punch Man', 'Superhero').
genre('My Hero Academia', 'Action').
genre('My Hero Academia', 'Superhero').
genre('My Hero Academia', 'School').
genre('Demon Slayer', 'Action').
genre('Demon Slayer', 'Fantasy').
genre('Demon Slayer', 'Historical').
genre('Violet Evergarden', 'Drama').
genre('Violet Evergarden', 'Fantasy').
genre('Violet Evergarden', 'Slice of Life').
genre('Cowboy Bebop', 'Space Western').
genre('Cowboy Bebop', 'Neo-noir').
genre('Cowboy Bebop', 'Action').
genre('Naruto', 'Action').
genre('Naruto', 'Adventure').
genre('Naruto', 'Martial Arts').
genre('One Piece', 'Adventure').
genre('One Piece', 'Fantasy').
genre('One Piece', 'Comedy').
genre('Hunter x Hunter', 'Adventure').
genre('Hunter x Hunter', 'Fantasy').
genre('Hunter x Hunter', 'Martial Arts').
genre('Neon Genesis Evangelion', 'Mecha').
genre('Neon Genesis Evangelion', 'Psychological').
genre('Neon Genesis Evangelion', 'Apocalyptic').
genre('Your Lie in April', 'Drama').
genre('Your Lie in April', 'Music').
genre('Your Lie in April', 'Romance').
genre('Spirited Away', 'Fantasy').
genre('Spirited Away', 'Adventure').
genre('Spirited Away', 'Coming of Age').
genre('Princess Mononoke', 'Fantasy').
genre('Princess Mononoke', 'Adventure').
genre('Princess Mononoke', 'Environmental').
genre('Jujutsu Kaisen', 'Action').
genre('Jujutsu Kaisen', 'Supernatural').
genre('Jujutsu Kaisen', 'Dark Fantasy').
genre('Vinland Saga', 'Action').
genre('Vinland Saga', 'Adventure').
genre('Vinland Saga', 'Historical').
genre('Monster', 'Mystery').
genre('Monster', 'Psychological').
genre('Monster', 'Thriller').
genre('Berserk', 'Dark Fantasy').
genre('Berserk', 'Action').
genre('Berserk', 'Horror').

% Target demographics
demographic('Fullmetal Alchemist: Brotherhood', 'Shounen').
demographic('Death Note', 'Shounen').
demographic('Attack on Titan', 'Shounen').
demographic('Steins;Gate', 'Seinen').
demographic('One Punch Man', 'Seinen').
demographic('My Hero Academia', 'Shounen').
demographic('Demon Slayer', 'Shounen').
demographic('Violet Evergarden', 'Seinen').
demographic('Cowboy Bebop', 'Seinen').
demographic('Naruto', 'Shounen').
demographic('One Piece', 'Shounen').
demographic('Hunter x Hunter', 'Shounen').
demographic('Neon Genesis Evangelion', 'Shounen').
demographic('Your Lie in April', 'Shounen').
demographic('Spirited Away', 'Family').
demographic('Princess Mononoke', 'Seinen').
demographic('Jujutsu Kaisen', 'Shounen').
demographic('Vinland Saga', 'Seinen').
demographic('Monster', 'Seinen').
demographic('Berserk', 'Seinen').

% Ratings - rating(Title, Source, Score)
rating('Fullmetal Alchemist: Brotherhood', 'MyAnimeList', 9.13).
rating('Death Note', 'MyAnimeList', 8.62).
rating('Attack on Titan', 'MyAnimeList', 8.53).
rating('Steins;Gate', 'MyAnimeList', 9.08).
rating('One Punch Man', 'MyAnimeList', 8.51).
rating('My Hero Academia', 'MyAnimeList', 7.98).
rating('Demon Slayer', 'MyAnimeList', 8.54).
rating('Violet Evergarden', 'MyAnimeList', 8.67).
rating('Cowboy Bebop', 'MyAnimeList', 8.75).
rating('Naruto', 'MyAnimeList', 7.98).
rating('One Piece', 'MyAnimeList', 8.69).
rating('Hunter x Hunter', 'MyAnimeList', 9.05).
rating('Neon Genesis Evangelion', 'MyAnimeList', 8.33).
rating('Your Lie in April', 'MyAnimeList', 8.65).
rating('Spirited Away', 'MyAnimeList', 8.77).
rating('Princess Mononoke', 'MyAnimeList', 8.75).
rating('Jujutsu Kaisen', 'MyAnimeList', 8.67).
rating('Vinland Saga', 'MyAnimeList', 8.73).
rating('Monster', 'MyAnimeList', 8.67).
rating('Berserk', 'MyAnimeList', 8.54).

% ==========================================
% PART 2: ANIME CHARACTERS
% ==========================================

% Character information - character(Name, Anime, Role, Gender)
character('Edward Elric', 'Fullmetal Alchemist: Brotherhood', 'Protagonist', 'Male').
character('Alphonse Elric', 'Fullmetal Alchemist: Brotherhood', 'Main', 'Male').
character('Roy Mustang', 'Fullmetal Alchemist: Brotherhood', 'Supporting', 'Male').
character('Winry Rockbell', 'Fullmetal Alchemist: Brotherhood', 'Supporting', 'Female').
character('Light Yagami', 'Death Note', 'Protagonist', 'Male').
character('L Lawliet', 'Death Note', 'Deuteragonist', 'Male').
character('Misa Amane', 'Death Note', 'Supporting', 'Female').
character('Eren Yeager', 'Attack on Titan', 'Protagonist', 'Male').
character('Mikasa Ackerman', 'Attack on Titan', 'Main', 'Female').
character('Armin Arlert', 'Attack on Titan', 'Main', 'Male').
character('Levi Ackerman', 'Attack on Titan', 'Supporting', 'Male').
character('Okabe Rintarou', 'Steins;Gate', 'Protagonist', 'Male').
character('Makise Kurisu', 'Steins;Gate', 'Main', 'Female').
character('Mayuri Shiina', 'Steins;Gate', 'Supporting', 'Female').
character('Saitama', 'One Punch Man', 'Protagonist', 'Male').
character('Genos', 'One Punch Man', 'Main', 'Male').
character('Izuku Midoriya', 'My Hero Academia', 'Protagonist', 'Male').
character('Katsuki Bakugo', 'My Hero Academia', 'Main', 'Male').
character('Ochako Uraraka', 'My Hero Academia', 'Main', 'Female').
character('All Might', 'My Hero Academia', 'Supporting', 'Male').
character('Tanjiro Kamado', 'Demon Slayer', 'Protagonist', 'Male').
character('Nezuko Kamado', 'Demon Slayer', 'Main', 'Female').
character('Zenitsu Agatsuma', 'Demon Slayer', 'Main', 'Male').
character('Inosuke Hashibira', 'Demon Slayer', 'Main', 'Male').
character('Violet Evergarden', 'Violet Evergarden', 'Protagonist', 'Female').
character('Gilbert Bougainvillea', 'Violet Evergarden', 'Supporting', 'Male').
character('Spike Spiegel', 'Cowboy Bebop', 'Protagonist', 'Male').
character('Faye Valentine', 'Cowboy Bebop', 'Main', 'Female').
character('Jet Black', 'Cowboy Bebop', 'Main', 'Male').
character('Edward Wong', 'Cowboy Bebop', 'Supporting', 'Female').
character('Naruto Uzumaki', 'Naruto', 'Protagonist', 'Male').
character('Sasuke Uchiha', 'Naruto', 'Main', 'Male').
character('Sakura Haruno', 'Naruto', 'Main', 'Female').
character('Kakashi Hatake', 'Naruto', 'Supporting', 'Male').
character('Monkey D. Luffy', 'One Piece', 'Protagonist', 'Male').
character('Roronoa Zoro', 'One Piece', 'Main', 'Male').
character('Nami', 'One Piece', 'Main', 'Female').
character('Gon Freecss', 'Hunter x Hunter', 'Protagonist', 'Male').
character('Killua Zoldyck', 'Hunter x Hunter', 'Main', 'Male').
character('Kurapika', 'Hunter x Hunter', 'Main', 'Male').
character('Leorio Paradinight', 'Hunter x Hunter', 'Main', 'Male').
character('Shinji Ikari', 'Neon Genesis Evangelion', 'Protagonist', 'Male').
character('Rei Ayanami', 'Neon Genesis Evangelion', 'Main', 'Female').
character('Asuka Langley Soryu', 'Neon Genesis Evangelion', 'Main', 'Female').
character('Kousei Arima', 'Your Lie in April', 'Protagonist', 'Male').
character('Kaori Miyazono', 'Your Lie in April', 'Main', 'Female').
character('Chihiro Ogino', 'Spirited Away', 'Protagonist', 'Female').
character('Haku', 'Spirited Away', 'Supporting', 'Male').
character('San', 'Princess Mononoke', 'Main', 'Female').
character('Ashitaka', 'Princess Mononoke', 'Protagonist', 'Male').
character('Yuji Itadori', 'Jujutsu Kaisen', 'Protagonist', 'Male').
character('Megumi Fushiguro', 'Jujutsu Kaisen', 'Main', 'Male').
character('Nobara Kugisaki', 'Jujutsu Kaisen', 'Main', 'Female').
character('Thorfinn', 'Vinland Saga', 'Protagonist', 'Male').
character('Askeladd', 'Vinland Saga', 'Main', 'Male').
character('Kenzo Tenma', 'Monster', 'Protagonist', 'Male').
character('Johan Liebert', 'Monster', 'Antagonist', 'Male').
character('Guts', 'Berserk', 'Protagonist', 'Male').
character('Griffith', 'Berserk', 'Antagonist', 'Male').
character('Casca', 'Berserk', 'Main', 'Female').

% Character traits - has_trait(Character, Trait)
has_trait('Edward Elric', 'Short-tempered').
has_trait('Edward Elric', 'Determined').
has_trait('Edward Elric', 'Genius').
has_trait('Alphonse Elric', 'Kind').
has_trait('Alphonse Elric', 'Patient').
has_trait('Roy Mustang', 'Ambitious').
has_trait('Roy Mustang', 'Strategic').
has_trait('Light Yagami', 'Intelligent').
has_trait('Light Yagami', 'Manipulative').
has_trait('Light Yagami', 'Narcissistic').
has_trait('L Lawliet', 'Eccentric').
has_trait('L Lawliet', 'Genius').
has_trait('Eren Yeager', 'Determined').
has_trait('Eren Yeager', 'Vengeful').
has_trait('Mikasa Ackerman', 'Protective').
has_trait('Mikasa Ackerman', 'Skilled').
has_trait('Levi Ackerman', 'Strong').
has_trait('Levi Ackerman', 'Disciplined').
has_trait('Okabe Rintarou', 'Eccentric').
has_trait('Okabe Rintarou', 'Determined').
has_trait('Makise Kurisu', 'Intelligent').
has_trait('Makise Kurisu', 'Tsundere').
has_trait('Saitama', 'Apathetic').
has_trait('Saitama', 'Overpowered').
has_trait('Izuku Midoriya', 'Analytical').
has_trait('Izuku Midoriya', 'Selfless').
has_trait('Katsuki Bakugo', 'Hot-headed').
has_trait('Katsuki Bakugo', 'Competitive').
has_trait('Tanjiro Kamado', 'Kind').
has_trait('Tanjiro Kamado', 'Determined').
has_trait('Nezuko Kamado', 'Protective').
has_trait('Violet Evergarden', 'Stoic').
has_trait('Violet Evergarden', 'Loyal').
has_trait('Spike Spiegel', 'Laid-back').
has_trait('Spike Spiegel', 'Skilled').
has_trait('Naruto Uzumaki', 'Determined').
has_trait('Naruto Uzumaki', 'Optimistic').
has_trait('Sasuke Uchiha', 'Vengeful').
has_trait('Sasuke Uchiha', 'Skilled').
has_trait('Monkey D. Luffy', 'Carefree').
has_trait('Monkey D. Luffy', 'Determined').
has_trait('Gon Freecss', 'Naive').
has_trait('Gon Freecss', 'Determined').
has_trait('Killua Zoldyck', 'Skilled').
has_trait('Killua Zoldyck', 'Protective').
has_trait('Shinji Ikari', 'Insecure').
has_trait('Shinji Ikari', 'Depressed').
has_trait('Rei Ayanami', 'Stoic').
has_trait('Asuka Langley Soryu', 'Competitive').
has_trait('Asuka Langley Soryu', 'Insecure').
has_trait('Kousei Arima', 'Depressed').
has_trait('Kousei Arima', 'Talented').
has_trait('Kaori Miyazono', 'Upbeat').
has_trait('Kaori Miyazono', 'Passionate').
has_trait('Chihiro Ogino', 'Brave').
has_trait('Chihiro Ogino', 'Kind').
has_trait('San', 'Wild').
has_trait('San', 'Fierce').
has_trait('Ashitaka', 'Compassionate').
has_trait('Ashitaka', 'Just').
has_trait('Yuji Itadori', 'Kind').
has_trait('Yuji Itadori', 'Athletic').
has_trait('Thorfinn', 'Vengeful').
has_trait('Thorfinn', 'Skilled').
has_trait('Askeladd', 'Cunning').
has_trait('Askeladd', 'Strategic').
has_trait('Kenzo Tenma', 'Principled').
has_trait('Kenzo Tenma', 'Determined').
has_trait('Johan Liebert', 'Manipulative').
has_trait('Johan Liebert', 'Intelligent').
has_trait('Guts', 'Resilient').
has_trait('Guts', 'Strong').
has_trait('Griffith', 'Ambitious').
has_trait('Griffith', 'Charismatic').

% Power systems - has_power(Character, PowerType, PowerDescription)
has_power('Edward Elric', 'Alchemy', 'Transmutation without circles').
has_power('Alphonse Elric', 'Alchemy', 'Soul bound to armor').
has_power('Roy Mustang', 'Alchemy', 'Fire/flame alchemy').
has_power('Light Yagami', 'Death Note', 'Kills by writing names').
has_power('Misa Amane', 'Death Note', 'Shinigami eyes').
has_power('Eren Yeager', 'Titan', 'Attack Titan shifter').
has_power('Mikasa Ackerman', 'Genetic', 'Ackerman strength').
has_power('Levi Ackerman', 'Genetic', 'Ackerman strength').
has_power('Okabe Rintarou', 'Technology', 'Time leap machine').
has_power('Saitama', 'Physical', 'Limitless strength').
has_power('Genos', 'Cybernetic', 'Mechanical body enhancements').
has_power('Izuku Midoriya', 'Quirk', 'One For All').
has_power('Katsuki Bakugo', 'Quirk', 'Explosion').
has_power('Ochako Uraraka', 'Quirk', 'Zero Gravity').
has_power('All Might', 'Quirk', 'One For All').
has_power('Tanjiro Kamado', 'Breathing Style', 'Water Breathing').
has_power('Nezuko Kamado', 'Demon', 'Blood Demon Art').
has_power('Zenitsu Agatsuma', 'Breathing Style', 'Thunder Breathing').
has_power('Inosuke Hashibira', 'Breathing Style', 'Beast Breathing').
has_power('Spike Spiegel', 'Martial Arts', 'Jeet Kune Do').
has_power('Naruto Uzumaki', 'Ninjutsu', 'Rasengan').
has_power('Naruto Uzumaki', 'Bijuu', 'Nine-Tails Jinchuriki').
has_power('Sasuke Uchiha', 'Dojutsu', 'Sharingan').
has_power('Sasuke Uchiha', 'Ninjutsu', 'Chidori').
has_power('Kakashi Hatake', 'Dojutsu', 'Sharingan').
has_power('Monkey D. Luffy', 'Devil Fruit', 'Gomu Gomu no Mi').
has_power('Roronoa Zoro', 'Sword', 'Three Sword Style').
has_power('Gon Freecss', 'Nen', 'Enhancement').
has_power('Killua Zoldyck', 'Nen', 'Transmutation').
has_power('Kurapika', 'Nen', 'Specialization').
has_power('Shinji Ikari', 'Eva', 'Eva Unit 01 Pilot').
has_power('Rei Ayanami', 'Eva', 'Eva Unit 00 Pilot').
has_power('Asuka Langley Soryu', 'Eva', 'Eva Unit 02 Pilot').
has_power('Yuji Itadori', 'Cursed Energy', 'Sukuna Vessel').
has_power('Megumi Fushiguro', 'Cursed Technique', 'Ten Shadows').
has_power('Nobara Kugisaki', 'Cursed Technique', 'Straw Doll').
has_power('Guts', 'Weapon', 'Dragonslayer Sword').
has_power('Griffith', 'God Hand', 'Femto transformation').

% ==========================================
% PART 3: ANIME WORLD BUILDING
% ==========================================

% World settings - world_setting(Anime, WorldType, TimePeriod, Description)
world_setting('Fullmetal Alchemist: Brotherhood', 'Alternate History', '1900s', 'World where alchemy is an advanced science').
world_setting('Death Note', 'Contemporary', '2000s', 'Modern Japan with supernatural elements').
world_setting('Attack on Titan', 'Dystopian', 'Medieval with technology', 'Humans live within walls to protect from Titans').
world_setting('Steins;Gate', 'Science Fiction', '2010', 'Modern Akihabara with time travel technology').
world_setting('One Punch Man', 'Superhero', 'Modern', 'Earth with frequent monster attacks and hero organization').
world_setting('My Hero Academia', 'Superhero', 'Near future', 'World where 80% of population has superpowers').
world_setting('Demon Slayer', 'Historical Fantasy', 'Taisho Era Japan', 'Japan with demons and demon slayers').
world_setting('Violet Evergarden', 'Post-War', 'Early 1900s', 'European-inspired continent after a major war').
world_setting('Cowboy Bebop', 'Space Western', '2071', 'Colonized solar system after Earth became uninhabitable').
world_setting('Naruto', 'Fantasy', 'Undefined', 'World of ninja villages with supernatural abilities').
world_setting('One Piece', 'Fantasy', 'Great Pirate Era', 'World of islands dominated by pirates and World Government').
world_setting('Hunter x Hunter', 'Fantasy', 'Modern', 'Earth-like world with special creatures and Nen abilities').
world_setting('Neon Genesis Evangelion', 'Post-Apocalyptic', '2015', 'Earth after Second Impact with Angel attacks').
world_setting('Your Lie in April', 'Contemporary', '2010s', 'Modern Japan focusing on classical music scene').
world_setting('Spirited Away', 'Fantasy', 'Modern', 'Modern Japan with hidden spirit world').
world_setting('Princess Mononoke', 'Historical Fantasy', 'Muromachi Period', 'Medieval Japan with forest spirits and gods').
world_setting('Jujutsu Kaisen', 'Urban Fantasy', 'Modern', 'Japan where negative emotions create curses').
world_setting('Vinland Saga', 'Historical', '11th Century', 'Viking Age in Northern Europe').
world_setting('Monster', 'Psychological Thriller', '1990s', 'Post-Cold War Germany and Eastern Europe').
world_setting('Berserk', 'Dark Fantasy', 'Medieval', 'Medieval European-inspired world with demons').

% Themes and motifs - has_theme(Anime, Theme)
has_theme('Fullmetal Alchemist: Brotherhood', 'Equivalent Exchange').
has_theme('Fullmetal Alchemist: Brotherhood', 'Brotherhood').
has_theme('Fullmetal Alchemist: Brotherhood', 'Corruption of Power').
has_theme('Death Note', 'Justice vs Evil').
has_theme('Death Note', 'Morality').
has_theme('Death Note', 'Power Corruption').
has_theme('Attack on Titan', 'Freedom').
has_theme('Attack on Titan', 'War').
has_theme('Attack on Titan', 'Truth and Deception').
has_theme('Steins;Gate', 'Butterfly Effect').
has_theme('Steins;Gate', 'Determinism vs Free Will').
has_theme('One Punch Man', 'Hero Recognition').
has_theme('One Punch Man', 'Meaning in Strength').
has_theme('My Hero Academia', 'Heroism').
has_theme('My Hero Academia', 'Legacy').
has_theme('Demon Slayer', 'Family Bonds').
has_theme('Demon Slayer', 'Humanity vs Monstrosity').
has_theme('Violet Evergarden', 'Understanding Emotion').
has_theme('Violet Evergarden', 'Post-War Recovery').
has_theme('Cowboy Bebop', 'Existentialism').
has_theme('Cowboy Bebop', 'Past Trauma').
has_theme('Naruto', 'Perseverance').
has_theme('Naruto', 'Found Family').
has_theme('One Piece', 'Adventure').
has_theme('One Piece', 'Freedom').
has_theme('Hunter x Hunter', 'Growth').
has_theme('Hunter x Hunter', 'Morality in Combat').
has_theme('Neon Genesis Evangelion', 'Psychological Trauma').
has_theme('Neon Genesis Evangelion', 'Human Connection').
has_theme('Your Lie in April', 'Grief').
has_theme('Your Lie in April', 'Performance Anxiety').
has_theme('Spirited Away', 'Identity').
has_theme('Spirited Away', 'Environmentalism').
has_theme('Princess Mononoke', 'Environmentalism').
has_theme('Princess Mononoke', 'Balance').
has_theme('Jujutsu Kaisen', 'Inner Demons').
has_theme('Jujutsu Kaisen', 'Self-Sacrifice').
has_theme('Vinland Saga', 'Revenge vs Peace').
has_theme('Vinland Saga', 'Finding Purpose').
has_theme('Monster', 'Nature vs Nurture').
has_theme('Monster', 'Identity').
has_theme('Berserk', 'Struggling Against Fate').
has_theme('Berserk', 'Trauma').

% Source material - adapted_from(Anime, SourceType, Creator, StartYear)
adapted_from('Fullmetal Alchemist: Brotherhood', 'Manga', 'Hiromu Arakawa', 2001).
adapted_from('Death Note', 'Manga', 'Tsugumi Ohba', 2003).
adapted_from('Attack on Titan', 'Manga', 'Hajime Isayama', 2009).
adapted_from('Steins;Gate', 'Visual Novel', '5pb. and Nitroplus', 2009).
adapted_from('One Punch Man', 'Webcomic', 'ONE', 2009).
adapted_from('My Hero Academia', 'Manga', 'Kohei Horikoshi', 2014).
adapted_from('Demon Slayer', 'Manga', 'Koyoharu Gotouge', 2016).
adapted_from('Violet Evergarden', 'Light Novel', 'Kana Akatsuki', 2015).
adapted_from('Cowboy Bebop', 'Original', 'Shinichiro Watanabe', 1998).
adapted_from('Naruto', 'Manga', 'Masashi Kishimoto', 1999).
adapted_from('One Piece', 'Manga', 'Eiichiro Oda', 1997).
adapted_from('Hunter x Hunter', 'Manga', 'Yoshihiro Togashi', 1998).
adapted_from('Neon Genesis Evangelion', 'Original', 'Hideaki Anno', 1995).
adapted_from('Your Lie in April', 'Manga', 'Naoshi Arakawa', 2011).
adapted_from('Spirited Away', 'Original', 'Hayao Miyazaki', 2001).
adapted_from('Princess Mononoke', 'Original', 'Hayao Miyazaki', 1997).
adapted_from('Jujutsu Kaisen', 'Manga', 'Gege Akutami', 2018).
adapted_from('Vinland Saga', 'Manga', 'Makoto Yukimura', 2005).
% Continuing from previous code...

adapted_from('Monster', 'Manga', 'Naoki Urasawa', 1994).
adapted_from('Berserk', 'Manga', 'Kentaro Miura', 1989).

% ==========================================
% PART 4: VIEWING AND COMMUNITY INFORMATION
% ==========================================

% Seasons and sequels - sequel_of(Sequel, Original)
sequel_of('Naruto Shippuden', 'Naruto').
sequel_of('My Hero Academia Season 2', 'My Hero Academia').
sequel_of('My Hero Academia Season 3', 'My Hero Academia Season 2').
sequel_of('My Hero Academia Season 4', 'My Hero Academia Season 3').
sequel_of('My Hero Academia Season 5', 'My Hero Academia Season 4').
sequel_of('Attack on Titan Season 2', 'Attack on Titan').
sequel_of('Attack on Titan Season 3', 'Attack on Titan Season 2').
sequel_of('Attack on Titan Final Season', 'Attack on Titan Season 3').
sequel_of('Demon Slayer: Mugen Train', 'Demon Slayer').
sequel_of('Demon Slayer: Entertainment District Arc', 'Demon Slayer: Mugen Train').
sequel_of('One Punch Man Season 2', 'One Punch Man').
sequel_of('Jujutsu Kaisen Season 2', 'Jujutsu Kaisen').

% Studios and their notable works
studio_work('Bones', 'Fullmetal Alchemist: Brotherhood').
studio_work('Bones', 'My Hero Academia').
studio_work('Bones', 'Soul Eater').
studio_work('Madhouse', 'Death Note').
studio_work('Madhouse', 'One Punch Man').
studio_work('Madhouse', 'Hunter x Hunter').
studio_work('Madhouse', 'Monster').
studio_work('Wit Studio', 'Attack on Titan').
studio_work('Wit Studio', 'Vinland Saga').
studio_work('Wit Studio', 'The Ancient Magus Bride').
studio_work('Ufotable', 'Demon Slayer').
studio_work('Ufotable', 'Fate/Zero').
studio_work('Ufotable', 'Fate/Stay Night: Unlimited Blade Works').
studio_work('Kyoto Animation', 'Violet Evergarden').
studio_work('Kyoto Animation', 'A Silent Voice').
studio_work('Kyoto Animation', 'K-On!').
studio_work('Studio Ghibli', 'Spirited Away').
studio_work('Studio Ghibli', 'Princess Mononoke').
studio_work('Studio Ghibli', 'My Neighbor Totoro').
studio_work('MAPPA', 'Jujutsu Kaisen').
studio_work('MAPPA', 'Attack on Titan Final Season').
studio_work('MAPPA', 'Chainsaw Man').

% Legal streaming availability - available_on(Anime, Platform)
available_on('Fullmetal Alchemist: Brotherhood', 'Crunchyroll').
available_on('Fullmetal Alchemist: Brotherhood', 'Netflix').
available_on('Death Note', 'Netflix').
available_on('Death Note', 'Hulu').
available_on('Attack on Titan', 'Crunchyroll').
available_on('Attack on Titan', 'Hulu').
available_on('Steins;Gate', 'Crunchyroll').
available_on('Steins;Gate', 'Funimation').
available_on('One Punch Man', 'Crunchyroll').
available_on('One Punch Man', 'Netflix').
available_on('My Hero Academia', 'Crunchyroll').
available_on('My Hero Academia', 'Funimation').
available_on('Demon Slayer', 'Netflix').
available_on('Demon Slayer', 'Crunchyroll').
available_on('Violet Evergarden', 'Netflix').
available_on('Cowboy Bebop', 'Netflix').
available_on('Cowboy Bebop', 'Funimation').
available_on('Naruto', 'Crunchyroll').
available_on('Naruto', 'Netflix').
available_on('One Piece', 'Crunchyroll').
available_on('One Piece', 'Funimation').
available_on('Hunter x Hunter', 'Crunchyroll').
available_on('Hunter x Hunter', 'Netflix').
available_on('Neon Genesis Evangelion', 'Netflix').
available_on('Your Lie in April', 'Netflix').
available_on('Your Lie in April', 'Crunchyroll').
available_on('Spirited Away', 'HBO Max').
available_on('Princess Mononoke', 'HBO Max').
available_on('Jujutsu Kaisen', 'Crunchyroll').
available_on('Vinland Saga', 'Amazon Prime').
available_on('Monster', 'None').
available_on('Berserk', 'Crunchyroll').

% Fan community information - community_metric(Anime, MetricType, Value)
community_metric('Fullmetal Alchemist: Brotherhood', 'MAL Members', 2800000).
community_metric('Death Note', 'MAL Members', 3100000).
community_metric('Attack on Titan', 'MAL Members', 3000000).
community_metric('Steins;Gate', 'MAL Members', 2200000).
community_metric('One Punch Man', 'MAL Members', 2100000).
community_metric('My Hero Academia', 'MAL Members', 2000000).
community_metric('Demon Slayer', 'MAL Members', 1900000).
community_metric('Violet Evergarden', 'MAL Members', 1300000).
community_metric('Cowboy Bebop', 'MAL Members', 1500000).
community_metric('Naruto', 'MAL Members', 2700000).
community_metric('One Piece', 'MAL Members', 2400000).
community_metric('Hunter x Hunter', 'MAL Members', 2000000).
community_metric('Neon Genesis Evangelion', 'MAL Members', 1400000).
community_metric('Your Lie in April', 'MAL Members', 1700000).
community_metric('Spirited Away', 'MAL Members', 1600000).
community_metric('Princess Mononoke', 'MAL Members', 1000000).
community_metric('Jujutsu Kaisen', 'MAL Members', 1500000).
community_metric('Vinland Saga', 'MAL Members', 800000).
community_metric('Monster', 'MAL Members', 700000).
community_metric('Berserk', 'MAL Members', 600000).

% ==========================================
% PART 5: RELATIONSHIPS AND CONNECTIONS
% ==========================================

% Character relationships - relationship(Character1, Character2, RelationType)
relationship('Edward Elric', 'Alphonse Elric', 'Siblings').
relationship('Edward Elric', 'Winry Rockbell', 'Love interest').
relationship('Light Yagami', 'L Lawliet', 'Rivals').
relationship('Light Yagami', 'Misa Amane', 'Manipulated ally').
relationship('Eren Yeager', 'Mikasa Ackerman', 'Family/Adoptive siblings').
relationship('Eren Yeager', 'Armin Arlert', 'Best friends').
relationship('Mikasa Ackerman', 'Levi Ackerman', 'Relatives').
relationship('Okabe Rintarou', 'Makise Kurisu', 'Love interest').
relationship('Okabe Rintarou', 'Mayuri Shiina', 'Childhood friends').
relationship('Saitama', 'Genos', 'Master-Disciple').
relationship('Izuku Midoriya', 'All Might', 'Master-Disciple').
relationship('Izuku Midoriya', 'Katsuki Bakugo', 'Rivals').
relationship('Izuku Midoriya', 'Ochako Uraraka', 'Friends/Potential romance').
relationship('Tanjiro Kamado', 'Nezuko Kamado', 'Siblings').
relationship('Tanjiro Kamado', 'Zenitsu Agatsuma', 'Friends').
relationship('Tanjiro Kamado', 'Inosuke Hashibira', 'Friends/Rivals').
relationship('Violet Evergarden', 'Gilbert Bougainvillea', 'Commander-Soldier/Love').
relationship('Spike Spiegel', 'Jet Black', 'Partners').
relationship('Spike Spiegel', 'Faye Valentine', 'Crewmates').
relationship('Naruto Uzumaki', 'Sasuke Uchiha', 'Best friends/Rivals').
relationship('Naruto Uzumaki', 'Sakura Haruno', 'Teammates').
relationship('Sasuke Uchiha', 'Sakura Haruno', 'Teammates/Love interest').
relationship('Naruto Uzumaki', 'Kakashi Hatake', 'Student-Teacher').
relationship('Monkey D. Luffy', 'Roronoa Zoro', 'Captain-First mate').
relationship('Monkey D. Luffy', 'Nami', 'Captain-Navigator').
relationship('Gon Freecss', 'Killua Zoldyck', 'Best friends').
relationship('Gon Freecss', 'Kurapika', 'Friends').
relationship('Gon Freecss', 'Leorio Paradinight', 'Friends').
relationship('Shinji Ikari', 'Rei Ayanami', 'Pilots/Complex').
relationship('Shinji Ikari', 'Asuka Langley Soryu', 'Pilots/Complex').
relationship('Rei Ayanami', 'Asuka Langley Soryu', 'Rivals').
relationship('Kousei Arima', 'Kaori Miyazono', 'Love interest').
relationship('Chihiro Ogino', 'Haku', 'Friends/Savior').
relationship('San', 'Ashitaka', 'Love interest').
relationship('Yuji Itadori', 'Megumi Fushiguro', 'Classmates/Friends').
relationship('Yuji Itadori', 'Nobara Kugisaki', 'Classmates/Friends').
relationship('Thorfinn', 'Askeladd', 'Enemies/Mentor').
relationship('Kenzo Tenma', 'Johan Liebert', 'Doctor-Patient/Hunter-Hunted').
relationship('Guts', 'Griffith', 'Former friends/Enemies').
relationship('Guts', 'Casca', 'Love interest').

% Similar anime recommendations - similar_to(Anime1, Anime2, SimilarityReason)
similar_to('Fullmetal Alchemist: Brotherhood', 'Hunter x Hunter', 'Adventure with complex power systems').
similar_to('Death Note', 'Monster', 'Psychological cat-and-mouse').
similar_to('Attack on Titan', 'Vinland Saga', 'Brutal historical setting with revenge themes').
similar_to('Steins;Gate', 'Re:Zero', 'Time manipulation and psychological suffering').
similar_to('One Punch Man', 'Mob Psycho 100', 'Same creator with overpowered protagonists').
similar_to('My Hero Academia', 'Black Clover', 'Shonen with magic/power systems and underdog protagonists').
similar_to('Demon Slayer', 'Jujutsu Kaisen', 'Modern shonen with supernatural combat').
similar_to('Violet Evergarden', 'A Silent Voice', 'Emotional healing and beautiful animation').
similar_to('Cowboy Bebop', 'Samurai Champloo', 'Same director with stylish action').
similar_to('Naruto', 'Bleach', 'Classic Big Three shonen').
similar_to('One Piece', 'Fairy Tail', 'Adventure with nakama themes').
similar_to('Neon Genesis Evangelion', 'Serial Experiments Lain', 'Psychological and philosophical themes').
similar_to('Your Lie in April', 'Anohana', 'Emotional drama with themes of loss').
similar_to('Spirited Away', 'Howl\'s Moving Castle', 'Miyazaki fantasy with coming-of-age themes').
similar_to('Princess Mononoke', 'Nausicaä of the Valley of the Wind', 'Miyazaki environmentalism themes').
similar_to('Berserk', 'Claymore', 'Dark fantasy with gore and supernatural elements').

% Director styles/trademarks - director_trademark(Director, Trademark)
director_trademark('Hayao Miyazaki', 'Environmental themes').
director_trademark('Hayao Miyazaki', 'Strong female protagonists').
director_trademark('Hayao Miyazaki', 'Detailed world-building').
director_trademark('Shinichiro Watanabe', 'Musical influences').
director_trademark('Shinichiro Watanabe', 'Genre mixing').
director_trademark('Hideaki Anno', 'Psychological exploration').
director_trademark('Hideaki Anno', 'Experimental animation techniques').
director_trademark('Tetsuro Araki', 'Dynamic action scenes').
director_trademark('Tetsuro Araki', 'Dark atmospheres').
director_trademark('Hiroshi Hamasaki', 'Nonlinear storytelling').
director_trademark('Masayuki Kojima', 'Character-driven narratives').
director_trademark('Hiroshi Koujina', 'Strategic battle sequences').

% ==========================================
% PART 6: RULES AND QUERIES
% ==========================================

% Is a sequel (direct or indirect)
is_sequel(Anime) :- sequel_of(Anime, _).

% Is an original story (not adapted)
is_original(Anime) :- adapted_from(Anime, 'Original', _, _).

% All anime available on a specific platform
platform_anime(Platform, Anime) :- available_on(Anime, Platform).

% Find all anime with a specific genre
genre_anime(GenreName, Anime) :- genre(Anime, GenreName).

% Find all anime with a specific theme
theme_anime(ThemeName, Anime) :- has_theme(Anime, ThemeName).

% Find characters with a specific trait
trait_characters(Trait, Character) :- has_trait(Character, Trait).

% Find anime with certain demographic
demographic_anime(Demo, Anime) :- demographic(Anime, Demo).

% Find anime by studio
studio_anime(Studio, Anime) :- studio_work(Studio, Anime).

% Find characters with similar traits
similar_characters(Char1, Char2) :-
    Char1 \= Char2,
    has_trait(Char1, Trait),
    has_trait(Char2, Trait).

% Find characters with same type of power
similar_powers(Char1, Char2) :-
    Char1 \= Char2,
    has_power(Char1, PowerType, _),
    has_power(Char2, PowerType, _).

% Count how many anime of a specific genre
count_genre_anime(Genre, Count) :-
    findall(Anime, genre(Anime, Genre), AnimeList),
    length(AnimeList, Count).

% Find anime released in a specific year
released_in_year(Year, Anime) :-
    anime(Anime, _, _, Year, _).

% Find anime with episodes count in range
episodes_in_range(Min, Max, Anime) :-
    anime(Anime, _, _, _, Episodes),
    Episodes >= Min,
    Episodes =< Max.

% Find anime with high ratings (above threshold)
high_rated(Threshold, Anime) :-
    rating(Anime, 'MyAnimeList', Score),
    Score >= Threshold.

% Find anime with a specific character
has_character(Anime, CharName) :-
    character(CharName, Anime, _, _).

% Find all protagonists
protagonist(Character) :-
    character(Character, _, 'Protagonist', _).

% Find female protagonists specifically
female_protagonist(Character) :-
    character(Character, _, 'Protagonist', 'Female').

% Find all antagonists
antagonist(Character) :-
    character(Character, _, 'Antagonist', _).

% Recommend anime based on genre preferences
recommend_by_genre(PreferredGenre, RecommendedAnime) :-
    genre(RecommendedAnime, PreferredGenre),
    rating(RecommendedAnime, 'MyAnimeList', Score),
    Score > 8.0.

% Recommend anime based on theme preferences
recommend_by_theme(PreferredTheme, RecommendedAnime) :-
    has_theme(RecommendedAnime, PreferredTheme),
    rating(RecommendedAnime, 'MyAnimeList', Score),
    Score > 8.0.

% Find anime with similar world settings
similar_setting(Anime1, Anime2) :-
    Anime1 \= Anime2,
    world_setting(Anime1, WorldType, _, _),
    world_setting(Anime2, WorldType, _, _).

% Find all characters in a specific relationship
find_relationship(RelationType, Char1, Char2) :-
    relationship(Char1, Char2, RelationType).

% Find anime with the most episodes
most_episodes(Anime, Episodes) :-
    anime(Anime, _, _, _, Episodes),
    not((anime(_, _, _, _, E), E > Episodes)).

% Find director's works
director_works(Director, Anime) :-
    anime(Anime, _, Director, _, _).

% Find anime of a certain genre created after a specific year
recent_genre(Genre, Year, Anime) :-
    genre(Anime, Genre),
    anime(Anime, _, _, ReleaseYear, _),
    ReleaseYear >= Year.

% Advanced recommendation system based on multiple factors
advanced_recommendation(PreferredAnime, RecommendedAnime) :-
    PreferredAnime \= RecommendedAnime,
    anime(PreferredAnime, _, _, _, _),
    anime(RecommendedAnime, _, _, _, _),
    (similar_to(PreferredAnime, RecommendedAnime, _);
    similar_to(RecommendedAnime, PreferredAnime, _);
    (genre(PreferredAnime, Genre), genre(RecommendedAnime, Genre));
    (has_theme(PreferredAnime, Theme), has_theme(RecommendedAnime, Theme))),
    rating(RecommendedAnime, 'MyAnimeList', Score),
    Score >= 8.0.

% Find all anime where a specific character has a specific trait
character_with_trait_in_anime(Trait, Anime) :-
    has_trait(Character, Trait),
    character(Character, Anime, _, _).

% Find all anime with a specific combination of genres
genre_combination(Genre1, Genre2, Anime) :-
    genre(Anime, Genre1),
    genre(Anime, Genre2),
    Genre1 @< Genre2.  % Ensure unique combinations

% Popular anime (based on MAL members)
is_popular(Anime) :-
    community_metric(Anime, 'MAL Members', Members),
    Members > 2000000.

% Cult classic (older anime that's still highly rated)
cult_classic(Anime) :-
    anime(Anime, _, _, Year, _),
    Year < 2000,
    rating(Anime, 'MyAnimeList', Score),
    Score > 8.5.

% Find all anime with a specific theme and demographic
theme_demographic(Theme, Demo, Anime) :-
    has_theme(Anime, Theme),
    demographic(Anime, Demo).

% ==========================================
% PART 7: SPECIALIZED KNOWLEDGE AREAS
% ==========================================

% Voice actors - voiced_by(Character, VoiceActor, Language)
voiced_by('Edward Elric', 'Romi Park', 'Japanese').
voiced_by('Edward Elric', 'Vic Mignogna', 'English').
voiced_by('Light Yagami', 'Mamoru Miyano', 'Japanese').
voiced_by('Light Yagami', 'Brad Swaile', 'English').
voiced_by('Eren Yeager', 'Yuki Kaji', 'Japanese').
voiced_by('Eren Yeager', 'Bryce Papenbrook', 'English').
voiced_by('Spike Spiegel', 'Koichi Yamadera', 'Japanese').
voiced_by('Spike Spiegel', 'Steve Blum', 'English').
voiced_by('Naruto Uzumaki', 'Junko Takeuchi', 'Japanese').
voiced_by('Naruto Uzumaki', 'Maile Flanagan', 'English').

% Animation techniques used in specific anime
animation_technique('Violet Evergarden', 'Rotoscoping').
animation_technique('Violet Evergarden', 'Digital painting').
animation_technique('Demon Slayer', 'Dynamic 3D camera').
animation_technique('Demon Slayer', 'Digital effects integration').
animation_technique('Spirited Away', 'Traditional hand-drawn').
animation_technique('Spirited Away', 'Watercolor backgrounds').
animation_technique('Attack on Titan', '3D gear animation').
animation_technique('One Punch Man', 'Sakuga animation').
animation_technique('Mob Psycho 100', 'Mixed media techniques').

% Music composers and notable soundtracks
soundtrack('Fullmetal Alchemist: Brotherhood', 'Akira Senju', 'Again').
soundtrack('Attack on Titan', 'Hiroyuki Sawano', 'Guren no Yumiya').
soundtrack('Cowboy Bebop', 'Yoko Kanno', 'Tank!').
soundtrack('Your Lie in April', 'Masaru Yokoyama', 'Hikaru Nara').
soundtrack('Demon Slayer', 'Yuki Kajiura', 'Gurenge').
soundtrack('Neon Genesis Evangelion', 'Shirō Sagisu', 'A Cruel Angel\'s Thesis').

% Awards and recognitions
award('Spirited Away', 'Academy Award', 'Best Animated Feature', 2003).
award('Your Name', 'Japan Academy Prize', 'Animation of the Year', 2016).
award('Demon Slayer: Mugen Train', 'Japan Academy Prize', 'Animation of the Year', 2020).
award('In This Corner of the World', 'Japan Academy Prize', 'Animation of the Year', 2017).
award('Violet Evergarden', 'Crunchyroll Anime Awards', 'Best Animation', 2019).

% Anime film vs series adaptation
film_adaptation('Demon Slayer: Mugen Train', 'Demon Slayer').
film_adaptation('Made in Abyss: Dawn of the Deep Soul', 'Made in Abyss').
film_adaptation('Violet Evergarden: The Movie', 'Violet Evergarden').
film_adaptation('My Hero Academia: Two Heroes', 'My Hero Academia').
film_adaptation('Sword Art Online: Ordinal Scale', 'Sword Art Online').

% Cultural impact and references
cultural_impact('Neon Genesis Evangelion', 'Otaku culture revolution').
cultural_impact('Sailor Moon', 'Magical girl genre popularization').
cultural_impact('Dragon Ball', 'Global shonen influence').
cultural_impact('Ghost in the Shell', 'Cyberpunk aesthetics in media').
cultural_impact('Akira', 'Cyberpunk anime aesthetics').
cultural_impact('Naruto', 'Ninja running meme').
cultural_impact('Initial D', 'Drift culture and eurobeat music').

% Anime industry economics
financial_success('Demon Slayer: Mugen Train', 'Highest grossing Japanese film', 506000000).
financial_success('Your Name', 'Second highest grossing anime film', 380000000).
financial_success('Spirited Away', 'Classic highest grosser', 355000000).
financial_success('One Piece', 'Highest manga sales', 490000000).
financial_success('Dragon Ball', 'Global merchandising', 'Unknown').

% Adaptation quality assessment - adaptation_quality(Anime, Faithfulness, AddedValue)
adaptation_quality('Fullmetal Alchemist: Brotherhood', 'High', 'Streamlined story').
adaptation_quality('Death Note', 'High', 'Enhanced atmosphere').
adaptation_quality('Attack on Titan', 'High', 'Dynamic action scenes').
adaptation_quality('One Punch Man Season 1', 'High', 'Elevated animation').
adaptation_quality('One Punch Man Season 2', 'Medium', 'Decreased animation quality').
adaptation_quality('Tokyo Ghoul:re', 'Low', 'Rushed pacing').
adaptation_quality('The Promised Neverland Season 2', 'Very Low', 'Skipped content').

% Rules for advanced queries

% Find voice actors who worked on multiple listed anime
prolific_voice_actor(Actor, Language, Count) :-
    findall(Character, voiced_by(Character, Actor, Language), Characters),
    length(Characters, Count),
    Count > 1.

% Find anime with outstanding music (with notable soundtracks)
musical_excellence(Anime) :-
    soundtrack(Anime, _, SongTitle),
    cultural_impact(SongTitle, _).

% Anime with both critical acclaim and financial success
commercial_critical_success(Anime) :-
    award(Anime, _, _, _),
    financial_success(Anime, _, _).

% Anime with significant cultural impact and high ratings
culturally_significant(Anime) :-
    cultural_impact(Anime, _),
    rating(Anime, 'MyAnimeList', Score),
    Score > 8.0.

% Find anime with technical animation excellence
animation_excellence(Anime) :-
    animation_technique(Anime, Technique),
    (Technique = 'Sakuga animation';
     Technique = 'Digital painting';
     Technique = 'Digital effects integration').

% Find series that have film adaptations
expanded_universe(Anime) :-
    film_adaptation(_, Anime).

% Find anime by the same director with similar themes
director_theme_pattern(Director, Theme, Anime1, Anime2) :-
    Anime1 \= Anime2,
    anime(Anime1, _, Director, _, _),
    anime(Anime2, _, Director, _, _),
    has_theme(Anime1, Theme),
    has_theme(Anime2, Theme).

% Advanced adaptation analysis - identify trends
adaptation_trend(SourceType, AdaptationQuality, Count) :-
    findall(Anime, (adapted_from(Anime, SourceType, _, _), adaptation_quality(Anime, AdaptationQuality, _)), AnimeList),
    length(AnimeList, Count).

% Example queries:
% Find all action anime released after 2015:
% ?- genre(Anime, 'Action'), anime(Anime, _, _, Year, _), Year >= 2015.

% Find all characters with "Determined" trait in popular anime:
% ?- has_trait(Character, 'Determined'), character(Character, Anime, _, _), is_popular(Anime).

% Recommend anime similar to "Death Note":
% ?- advanced_recommendation('Death Note', Recommendation).

% Find all anime available on both Netflix and Crunchyroll:
% ?- available_on(Anime, 'Netflix'), available_on(Anime, 'Crunchyroll').

% Find anime with psychological themes and high ratings:
% ?- has_theme(Anime, 'Psychological'), high_rated(8.5, Anime).