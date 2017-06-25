/*-------------
OJam 2017
23 - 25/06
Bruno
Demetrio
Felipe
-------------*/

//=== inicio ===

-	Hi, Honey!
	* Hi
	* Hello!
	* Hum

-	How are you, my beloved? :)
	* I was better before[...] you texted me -> babaca_path1
	* I'm good! How about you? []Did you have fun yesterday? -> drunk_path1
	* I'm not ok //-> reg_path1


-	(babaca_path1) Geez... I just wanted to know how you were...
	* I'm ok[...], are you satisfied now? -> babaca_path2
	* I'm trying to[...] remember our date yesterday, F. -> drunk_path3
	* Nevermind //-> reg_path4
	
	- -	(babaca_path2) I would be if you showed a little more consideration!
		* * You're right. Maybe I should[...] get you a dog, since you need that much attention. -> babaca_path3
		* * Dear, you're special and[...] your body looks a warm croissant -> babaca_path4
		* * Maybe I'm not[...] ok. //-> reg_path4

		- - - (babaca_path3) WHAT!? What's wrong with you?
				* * * Perhaps I'm not on my best mood[...], SINCE YOU DON'T STOP COMPLAINING. -> babaca_path4
				* * * Please, don't be mad! -> drunk_path4
				* * * ?
				
			- - - -	(babaca_path4) Stop right there! Before someone gets hurt here! Remember last time?
					* * * * Yeah, you are right. I remember[] you always getting upset over the little things -> babaca_path5
					* * * * ?
					* * * *	?
					
				- - - - - (babaca_path5) LITTLE THINGS!? You know how much I care about you!
							* * * * * Or so you say... -> babaca_path6
							* * * * * ?
							* * * * * Do you? //-> reg_path4

					- - - - - - (babaca_path6) I DO! Your are my precious... And I thought you felt the same way...
								* * * * * * Sorry[ :( ...], think again! -> babaca_path8
								* * * * * * Oh... So if I'm your precious[...] you're Smeagol!! LOL xD -> babaca_path7
								* * * * * *	Maybe.

						- - - - - - - (babaca_path7) MAYBE I SHOULD STOP HAVING YOU IN SUCH HIGH CONSIDERATION, RIGHT!?
										* * * * * * * Ok now, take a deep breath[...] and stop talking. -> babaca_path8
										* * * * * * * ?
										* * * * * * * ?

							- - - - - - - - (babaca_path8) WHY ARE YOU DOING THIS TO ME!?
											* * * * * * * * ... -> last
											* * * * * * * * I'm, sorry[...], Fran, I thought you enjoyed our night :/ -> last
											* * * * * * * * I... -> last
										

-	(drunk_path1) Yesterday? We didn't meet yesterday!
	* Shall we talk about [it?]memory problems again? -> babaca_path3
	* Course we did! It was the day I got my white [uniforn!]unicorn! -> drunk_path2
	* True. //-> reg_path3

	- - (drunk_path2) UNICORN? What are you talking about?
		* * Sending unicorn emoji in 5, 4... -> babaca_path3
		* * LOL! I said UNIFORM![] With an F, just like your name -> drunk_path3
		* * ?
	
		- - - (drunk_path3) Are you drunk? You know my name has no F!
				* * * LOL, true![] It has an S, like STUPID! -> babaca_path4
				* * * I'm kidding![] No, seriously, who are you? :O -> drunk_path4
				* * * Oh... //-> reg_path3
				
			- - - - (drunk_path4) See? That's what I get for being nice to you. Tell me what happened yesterday.
					* * * * Nothing[.], you're imagining things. -> babaca_path3
					* * * * I think I[ kissed the wrong person...] killed the wrong person... -> drunk_path5
					* * * * Nevermind //-> reg_path1

				- - - - - (drunk_path5) YOU WHAT!? OH MY GOD!!! OH MY GOD!!!
							* * * * * NO! Stupid corrector![] I said I KISSED somebody. -> drunk_path7
							* * * * * Come on, it's not the end of the world... -> drunk_path6
							* * * * * JK... -> drunk_path6

					- - - - - - (drunk_path6) I can't believe it! I'm calling the Police!
								* * * * * * I don't[...] care! -> babaca_path8
								* * * * * * Because of a kiss!? o.O -> drunk_path7
								* * * * * * ?
		
						- - - - - - - (drunk_path7) OMG! YOU'RE GIVING ME A HEART ATTACK... PLEASE SAY IT WAS ANOTHER TYPO...
										* * * * * * * I didn't want[...] to say, but I think you're being too emotional. -> babaca_path8
										* * * * * * * Yes, I may have[ kicked somebody yesterday, but I'd never...] licked somebody yesterday, but I'd never kill anyone. -> babaca_path8
										* * * * * * * I'm not sure... -> last
		
		
- (last) Do me a last favor and don't ever talk to me again

-> END
		
		

/*
-	(reg_path1) Really? Tell me what happened.
	* Do you really want to know? -> reg_path2
	* ?
	* It's ok, you don't have to bother -> reg_path2

	- - (reg_path2) You know I do. And you know you can trust me.
		* * REALLY? -> reg_path3
		* * ?
		* * Maybe I can, maybe not -> reg_path3
		
		- - - (reg_path3) I'm starting to get worried...
				* * * ? -> reg_pathX
				* * * ? -> reg_pathX
				* * * It's nothing... -> reg_path4
				
			- - - - (reg_path4) Please, sweetheart, tell me what happened.
					* * * * ?
					* * * * ?
					* * * * ?
*/





