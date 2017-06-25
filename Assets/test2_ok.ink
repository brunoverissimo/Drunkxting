/*-------------
OJam 2017
23 - 25/06
Bruno
Demetrio
Felipe
-------------*/

//=== start ===

-	Hi, Honey!
	* Hi
	* Hello!
	* Hum

-	How are you? :)
	* I was better before[...] you texted me -> babaca_path1
	* I'm good! How about you? []Did you have fun yesterday? -> drunk_path1
	* I'm not ok -> reg_path1


-	(babaca_path1) Geez... I just wanted to know how you were...
	* I'm ok[...], are you satisfied now? -> babaca_path2
	* I'm trying to[...] be ok
	* Nevermind
	
	- -	(babaca_path2) I would be if you showed a little more consideration!
		* * You're right. Maybe I should[...] get you a dog, since you need that much attention. -> babaca_path3
		* * ?
		* * OK

		- - - (babaca_path3) WHAT!? What's wrong with you?
				* * * Perhaps I'm not on my best mood[...], SINCE YOU DON'T STOP COMPLAINING. -> babaca_path4
				* * * ?
				* * * ?
				
			- - - -	(babaca_path4) Stop right there! Before someone gets hurt here! Remember last time?
					* * * * Yeah, you are right. I remember[] you always getting upset over the little things -> babaca_path5
					* * * * ?
					* * * *	?
					
				- - - - - (babaca_path5) LITTLE THINGS!? You know how much I care about you!
							* * * * * Or so you say... -> babaca_path6
							* * * * * ?
							* * * * * ?		

					- - - - - - (babaca_path6) I DO! Your are my precious... And I thought you felt the same way...
								* * * * * * Sorry[ :( ...], think again! -> babaca_path8
								* * * * * * Oh... So if I'm your precious[...] you're Smeagol!! LOL xD -> babaca_path7
								* * * * * *	?
								
						- - - - - - - (babaca_path7) MAYBE I SHOULD STOP HAVING YOU IN SUCH HIGH CONSIDERATION, RIGHT!?
										* * * * * * * Ok now, take a deep breath[...] and stop talking. -> babaca_path8
										* * * * * * * ?
										* * * * * * * ?

							- - - - - - - - (babaca_path8) WHY ARE YOU DOING THIS TO ME!?
											* * * * * * * * ... -> last
											* * * * * * * * ? -> last
											* * * * * * * * ? -> last
										

-	(drunk_path1) Yesterday? We didn't meet yesterday!
	* Shall we talk about [it?]memory problems again? -> babaca_path3
	* Of course we did! It was the day I got my white [uniforn!]unicorn! -> drunk_path2
	* True.

	- - (drunk_path2) UNICORN? What are you talking about?
		* * Sending unicorn emoji in 5, 4... -> babaca_path3
		* * I said UNIFORM![] With an F, just like your name -> drunk_path3
		* * ?
	
		- - - (drunk_path3) Are you drunk? You know my name has no F!
				* * * ?
				* * * Seriously? Who are you? :O > drunk_path4
				* * * Oh...
				
			- - - - (drunk_path4) See? That's what I get for being nice to you. Tell me what happened yesterday.
					* * * * Nothing
					* * * * I think I[ kissed the wrong person] killed the wrong person -_- -> drunk_path5
					* * * * Nevermind

				- - - - - (drunk_path5) YOU WHAT!? OH MY GOD!!! OH MY GOD!!!
							* * * * * NO! Stupid corrector![] I said I kissed somebody.
							* * * * * Come on, it's not the end of the world... -> drunk_path6
							* * * * * ?

					- - - - - - (drunk_path6) I'm calling the Police right now!
								* * * * * * ?
								* * * * * * Because of a kiss!? o.O -> drunk_path7
								* * * * * * ?
		
						- - - - - - - (drunk_path7) KISS!? OMG! YOU'RE GIVING ME A HEART ATTACK...
										* * * * * * * I didn't want[...] to say, but I think you're being too emotional. 
										* * * * * * * Yes, I may have [kicked somebody yesterday] licked somebody yesterday, but I would never kill anyone.
										* * * * * * * ?
		
/*
- - (drunk_pathX)
		What happened?
		* *	Nothing //-> are_you_sure
		* * I've just [kissed somebody] killed somebody
		* * (reg) Nevermind
*/




-	(reg_path1)
		

- (last) Do me a last favor and don't ever talk to me again

-> END 