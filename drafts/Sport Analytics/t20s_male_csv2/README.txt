All Men's T20 International match data in CSV format
====================================================

The background
--------------

As an experiment, after being asked by a user of the site, I started
converting the YAML data provided on the site into a CSV format. That
initial version was heavily influenced by the format used by the baseball
project Retrosheet. I wasn't sure of the usefulness of my CSV format, but
nothing better was suggested so I persisted with it. Later Ashwin Raman
(https://twitter.com/AshwinRaman_) send me a detailed example of a format
he felt might work and, liking what I saw, I started to produce data in
a slightly modified version of that initial example.

This particular zip folder contains the CSV data for...
  All Men's T20 International matches
...for which we have data.

How you can help
----------------

Providing feedback on the data would be the most helpful. Tell me what you
like and what you don't. Is there anything that is in the YAML data that
you'd like to be included in the CSV? Could something be included in a better
format? General views and comments help, as well as incredibly detailed
feedback. All information is of use to me at this stage. I can only improve
the data if people tell me what does works and what doesn't. I'd like to make
the data as useful as possible but I need your help to do it. Also, which of
the 2 CSV formats do you prefer, this one or the original? Ideally I'd like
to settle on a single CSV format so what should be kept from each?

Finally, any feedback as to the licence the data should be released under
would be greatly appreciated. Licensing is a strange little world and I'd
like to choose the "right" licence. My basic criteria may be that:

  * the data should be free,
  * corrections are encouraged/required to be reported to the project,
  * derivative works are allowed,
  * you can't just take data and sell it.

Feedback, pointers, comments, etc on licensing are welcome.

The format of the data
----------------------

Full documentation of this CSV format can be found at:
  https://cricsheet.org/format/csv_ashwin/
but the following is a brief summary of the details...

The first row of each CSV file contains the headers for the file, with each
subsequent row providing details on a single delivery. The headers in the
file are:

  * match_id
  * season
  * start_date
  * venue
  * innings
  * ball
  * batting_team
  * bowling_team
  * striker
  * non_striker
  * bowler
  * runs_off_bat
  * extras
  * wides
  * noballs
  * byes
  * legbyes
  * penalty
  * wicket_type
  * player_dismissed
  * other_wicket_type
  * other_player_dismissed

Most of the fields above should, hopefully, be self-explanatory, but some may
benefit from clarification...

"innings" contains the number of the innings within the match. If a match is
one that would normally have 2 innings, such as a T20 or ODI, then any innings
of more than 2 can be regarded as a super over.

"ball" is a combination of the over and delivery. For example, "0.3" represents
the 3rd ball of the 1st over.

"wides", "noballs", "byes", "legbyes", and "penalty" contain the total of each
particular type of extras, or are blank if not relevant to the delivery.

If a wicket occurred on a delivery then "wicket_type" will contain the method
of dismissal, while "player_dismissed" will indicate who was dismissed. There
is also the, admittedly remote, possibility that a second dismissal can be
recorded on the delivery (such as when a player retires on the same delivery
as another dismissal occurs). In this case "other_wicket_type" will record
the reason, while "other_player_dismissed" will show who was dismissed.

Matches included in this archive
--------------------------------

2021-05-23 - international - T20 - male - 1263712 - Austria vs Luxembourg
2021-05-23 - international - T20 - male - 1263713 - Czech Republic vs Austria
2021-05-22 - international - T20 - male - 1263710 - Austria vs Czech Republic
2021-05-22 - international - T20 - male - 1263711 - Czech Republic vs Luxembourg
2021-05-21 - international - T20 - male - 1263708 - Luxembourg vs Czech Republic
2021-04-25 - international - T20 - male - 1257185 - Pakistan vs Zimbabwe
2021-04-24 - international - T20 - male - 1257951 - Nepal vs Netherlands
2021-04-23 - international - T20 - male - 1257184 - Zimbabwe vs Pakistan
2021-04-22 - international - T20 - male - 1257950 - Nepal vs Malaysia
2021-04-21 - international - T20 - male - 1257183 - Pakistan vs Zimbabwe
2021-04-21 - international - T20 - male - 1257949 - Netherlands vs Malaysia
2021-04-20 - international - T20 - male - 1257948 - Nepal vs Netherlands
2021-04-19 - international - T20 - male - 1257947 - Malaysia vs Nepal
2021-04-18 - international - T20 - male - 1257946 - Netherlands vs Malaysia
2021-04-17 - international - T20 - male - 1257945 - Netherlands vs Nepal
2021-04-16 - international - T20 - male - 1251578 - South Africa vs Pakistan
2021-04-14 - international - T20 - male - 1251577 - South Africa vs Pakistan
2021-04-12 - international - T20 - male - 1251576 - Pakistan vs South Africa
2021-04-10 - international - T20 - male - 1251575 - South Africa vs Pakistan
2021-04-05 - international - T20 - male - 1257405 - Namibia vs Uganda
2021-04-05 - international - T20 - male - 1257406 - Namibia vs Uganda
2021-04-03 - international - T20 - male - 1257404 - Uganda vs Namibia
2021-04-01 - international - T20 - male - 1233981 - New Zealand vs Bangladesh
2021-03-30 - international - T20 - male - 1233980 - New Zealand vs Bangladesh
2021-03-28 - international - T20 - male - 1233979 - New Zealand vs Bangladesh
2021-03-20 - international - T20 - male - 1243392 - India vs England
2021-03-20 - international - T20 - male - 1252060 - Afghanistan vs Zimbabwe
2021-03-19 - international - T20 - male - 1252059 - Afghanistan vs Zimbabwe
2021-03-18 - international - T20 - male - 1243391 - India vs England
2021-03-17 - international - T20 - male - 1252058 - Afghanistan vs Zimbabwe
2021-03-16 - international - T20 - male - 1243390 - India vs England
2021-03-14 - international - T20 - male - 1243389 - England vs India
2021-03-12 - international - T20 - male - 1243388 - India vs England
2021-03-07 - international - T20 - male - 1233975 - Australia vs New Zealand
2021-03-07 - international - T20 - male - 1252068 - Sri Lanka vs West Indies
2021-03-05 - international - T20 - male - 1233974 - Australia vs New Zealand
2021-03-05 - international - T20 - male - 1252067 - Sri Lanka vs West Indies
2021-03-03 - international - T20 - male - 1233973 - Australia vs New Zealand
2021-03-03 - international - T20 - male - 1252066 - Sri Lanka vs West Indies
2021-02-25 - international - T20 - male - 1233972 - New Zealand vs Australia
2021-02-22 - international - T20 - male - 1233971 - New Zealand vs Australia
2021-02-14 - international - T20 - male - 1243021 - South Africa vs Pakistan
2021-02-13 - international - T20 - male - 1243020 - Pakistan vs South Africa
2021-02-11 - international - T20 - male - 1243019 - Pakistan vs South Africa
2020-12-22 - international - T20 - male - 1233961 - New Zealand vs Pakistan
2020-12-20 - international - T20 - male - 1233960 - Pakistan vs New Zealand
2020-12-18 - international - T20 - male - 1233959 - Pakistan vs New Zealand
2020-12-08 - international - T20 - male - 1223954 - Australia vs India
2020-12-06 - international - T20 - male - 1223953 - Australia vs India
2020-12-04 - international - T20 - male - 1223952 - India vs Australia
2020-12-01 - international - T20 - male - 1237124 - South Africa vs England
2020-11-30 - international - T20 - male - 1233956 - West Indies vs New Zealand
2020-11-29 - international - T20 - male - 1233955 - New Zealand vs West Indies
2020-11-29 - international - T20 - male - 1237123 - South Africa vs England
2020-11-27 - international - T20 - male - 1233954 - West Indies vs New Zealand
2020-11-27 - international - T20 - male - 1237122 - South Africa vs England
2020-11-10 - international - T20 - male - 1233466 - Zimbabwe vs Pakistan
2020-11-08 - international - T20 - male - 1233465 - Zimbabwe vs Pakistan
2020-11-07 - international - T20 - male - 1233464 - Zimbabwe vs Pakistan
2020-10-18 - international - T20 - male - 1235832 - Bulgaria vs Romania
2020-10-17 - international - T20 - male - 1235830 - Romania vs Bulgaria
2020-10-16 - international - T20 - male - 1235829 - Bulgaria vs Romania
2020-09-08 - international - T20 - male - 1198237 - England vs Australia
2020-09-06 - international - T20 - male - 1198236 - Australia vs England
2020-09-04 - international - T20 - male - 1198235 - England vs Australia
2020-09-01 - international - T20 - male - 1198246 - Pakistan vs England
2020-08-30 - international - T20 - male - 1198245 - Pakistan vs England
2020-08-30 - international - T20 - male - 1229822 - Belgium vs Czech Republic
2020-08-30 - international - T20 - male - 1229823 - Belgium vs Luxembourg
2020-08-29 - international - T20 - male - 1229820 - Belgium vs Luxembourg
2020-08-28 - international - T20 - male - 1198244 - England vs Pakistan
2020-08-21 - international - T20 - male - 1229824 - Isle of Man vs Guernsey
2020-03-11 - international - T20 - male - 1214671 - Bangladesh vs Zimbabwe
2020-03-10 - international - T20 - male - 1216418 - Afghanistan vs Ireland
2020-03-09 - international - T20 - male - 1214670 - Bangladesh vs Zimbabwe
2020-03-08 - international - T20 - male - 1207081 - Spain vs Germany
2020-03-08 - international - T20 - male - 1207082 - Spain vs Germany
2020-03-08 - international - T20 - male - 1216417 - Afghanistan vs Ireland
2020-03-06 - international - T20 - male - 1213875 - Sri Lanka vs West Indies
2020-03-06 - international - T20 - male - 1216416 - Afghanistan vs Ireland
2020-03-06 - international - T20 - male - 1217747 - Hong Kong vs Malaysia
2020-03-04 - international - T20 - male - 1213874 - Sri Lanka vs West Indies
2020-03-04 - international - T20 - male - 1217744 - Thailand vs Nepal
2020-03-04 - international - T20 - male - 1217745 - Hong Kong vs Singapore
2020-03-03 - international - T20 - male - 1217742 - Malaysia vs Singapore
2020-03-03 - international - T20 - male - 1217743 - Thailand vs Hong Kong
2020-03-01 - international - T20 - male - 1217740 - Hong Kong vs Nepal
2020-03-01 - international - T20 - male - 1217741 - Thailand vs Malaysia
2020-02-29 - international - T20 - male - 1217738 - Thailand vs Singapore
2020-02-27 - international - T20 - male - 1215165 - Kuwait vs United Arab Emirates
2020-02-26 - international - T20 - male - 1185318 - South Africa vs Australia
2020-02-26 - international - T20 - male - 1215140 - Malaysia vs Hong Kong
2020-02-26 - international - T20 - male - 1215163 - Kuwait vs Bahrain
2020-02-26 - international - T20 - male - 1215164 - Qatar vs United Arab Emirates
2020-02-25 - international - T20 - male - 1215159 - Oman vs Maldives
2020-02-25 - international - T20 - male - 1215160 - Saudi Arabia vs United Arab Emirates
2020-02-25 - international - T20 - male - 1215161 - Bahrain vs Qatar
2020-02-25 - international - T20 - male - 1215162 - Iran vs Kuwait
2020-02-24 - international - T20 - male - 1215139 - Malaysia vs Hong Kong
2020-02-23 - international - T20 - male - 1185317 - South Africa vs Australia
2020-02-23 - international - T20 - male - 1215138 - Malaysia vs Hong Kong
2020-02-21 - international - T20 - male - 1185316 - South Africa vs Australia
2020-02-21 - international - T20 - male - 1215137 - Malaysia vs Hong Kong
2020-02-20 - international - T20 - male - 1215136 - Malaysia vs Hong Kong
2020-02-16 - international - T20 - male - 1185315 - South Africa vs England
2020-02-14 - international - T20 - male - 1185314 - South Africa vs England
2020-02-12 - international - T20 - male - 1185313 - South Africa vs England
2020-02-02 - international - T20 - male - 1187681 - New Zealand vs India
2020-01-31 - international - T20 - male - 1187680 - New Zealand vs India
2020-01-29 - international - T20 - male - 1187679 - New Zealand vs India
2020-01-26 - international - T20 - male - 1187678 - New Zealand vs India
2020-01-25 - international - T20 - male - 1213059 - Pakistan vs Bangladesh
2020-01-24 - international - T20 - male - 1187677 - New Zealand vs India
2020-01-24 - international - T20 - male - 1213058 - Pakistan vs Bangladesh
2020-01-19 - international - T20 - male - 1203678 - West Indies vs Ireland
2020-01-18 - international - T20 - male - 1203677 - West Indies vs Ireland
2020-01-15 - international - T20 - male - 1203676 - West Indies vs Ireland
2020-01-10 - international - T20 - male - 1202244 - India vs Sri Lanka
2020-01-07 - international - T20 - male - 1202243 - India vs Sri Lanka
2019-12-11 - international - T20 - male - 1187020 - India vs West Indies
2019-12-09 - international - T20 - male - 1208613 - Nepal vs Maldives
2019-12-08 - international - T20 - male - 1187019 - India vs West Indies
2019-12-07 - international - T20 - male - 1208612 - Bhutan vs Maldives
2019-12-06 - international - T20 - male - 1187018 - India vs West Indies
2019-12-06 - international - T20 - male - 1208609 - Nepal vs Maldives
2019-12-05 - international - T20 - male - 1208606 - Nepal vs Bhutan
2019-11-17 - international - T20 - male - 1193496 - Afghanistan vs West Indies
2019-11-16 - international - T20 - male - 1193495 - Afghanistan vs West Indies
2019-11-14 - international - T20 - male - 1193494 - Afghanistan vs West Indies
2019-11-10 - international - T20 - male - 1187015 - India vs Bangladesh
2019-11-10 - international - T20 - male - 1187669 - New Zealand vs England
2019-11-08 - international - T20 - male - 1183529 - Australia vs Pakistan
2019-11-08 - international - T20 - male - 1187668 - New Zealand vs England
2019-11-07 - international - T20 - male - 1187014 - India vs Bangladesh
2019-11-05 - international - T20 - male - 1183528 - Australia vs Pakistan
2019-11-05 - international - T20 - male - 1187667 - New Zealand vs England
2019-11-03 - international - T20 - male - 1183527 - Australia vs Pakistan
2019-11-03 - international - T20 - male - 1187013 - India vs Bangladesh
2019-11-03 - international - T20 - male - 1187666 - New Zealand vs England
2019-11-02 - international - T20 - male - 1199548 - Ireland vs Namibia
2019-11-02 - international - T20 - male - 1199549 - Netherlands vs Papua New Guinea
2019-11-01 - international - T20 - male - 1183526 - Australia vs Sri Lanka
2019-11-01 - international - T20 - male - 1187665 - New Zealand vs England
2019-11-01 - international - T20 - male - 1199546 - Ireland vs Netherlands
2019-11-01 - international - T20 - male - 1199547 - Namibia vs Papua New Guinea
2019-10-31 - international - T20 - male - 1199545 - Oman vs Scotland
2019-10-30 - international - T20 - male - 1183525 - Australia vs Sri Lanka
2019-10-30 - international - T20 - male - 1199543 - United Arab Emirates vs Scotland
2019-10-30 - international - T20 - male - 1199544 - Hong Kong vs Oman
2019-10-29 - international - T20 - male - 1199541 - United Arab Emirates vs Netherlands
2019-10-29 - international - T20 - male - 1199542 - Namibia vs Oman
2019-10-27 - international - T20 - male - 1183524 - Australia vs Sri Lanka
2019-10-27 - international - T20 - male - 1199536 - Kenya vs Papua New Guinea
2019-10-27 - international - T20 - male - 1199537 - Hong Kong vs Nigeria
2019-10-27 - international - T20 - male - 1199538 - Jersey vs Oman
2019-10-27 - international - T20 - male - 1199539 - Netherlands vs Scotland
2019-10-27 - international - T20 - male - 1199540 - United Arab Emirates vs Canada
2019-10-27 - international - T20 - male - 1201673 - Spain vs Gibraltar
2019-10-26 - international - T20 - male - 1199533 - Ireland vs Nigeria
2019-10-26 - international - T20 - male - 1199534 - Bermuda vs Netherlands
2019-10-26 - international - T20 - male - 1199535 - Namibia vs Singapore
2019-10-26 - international - T20 - male - 1201669 - Gibraltar vs Portugal
2019-10-26 - international - T20 - male - 1201670 - Spain vs Gibraltar
2019-10-26 - international - T20 - male - 1201671 - Spain vs Portugal
2019-10-25 - international - T20 - male - 1199529 - Papua New Guinea vs Singapore
2019-10-25 - international - T20 - male - 1199530 - Ireland vs Jersey
2019-10-25 - international - T20 - male - 1199531 - Kenya vs Namibia
2019-10-25 - international - T20 - male - 1199532 - Canada vs Oman
2019-10-25 - international - T20 - male - 1201668 - Spain vs Portugal
2019-10-24 - international - T20 - male - 1199525 - Netherlands vs Papua New Guinea
2019-10-24 - international - T20 - male - 1199526 - United Arab Emirates vs Nigeria
2019-10-24 - international - T20 - male - 1199527 - Canada vs Hong Kong
2019-10-24 - international - T20 - male - 1199528 - Bermuda vs Scotland
2019-10-23 - international - T20 - male - 1199520 - Bermuda vs Namibia
2019-10-23 - international - T20 - male - 1199521 - Nigeria vs Oman
2019-10-23 - international - T20 - male - 1199522 - Kenya vs Singapore
2019-10-23 - international - T20 - male - 1199523 - Canada vs Ireland
2019-10-23 - international - T20 - male - 1199524 - Hong Kong vs Jersey
2019-10-22 - international - T20 - male - 1199517 - Namibia vs Scotland
2019-10-22 - international - T20 - male - 1199518 - Netherlands vs Singapore
2019-10-22 - international - T20 - male - 1199519 - United Arab Emirates vs Jersey
2019-10-21 - international - T20 - male - 1199512 - Papua New Guinea vs Scotland
2019-10-21 - international - T20 - male - 1199513 - United Arab Emirates vs Hong Kong
2019-10-21 - international - T20 - male - 1199514 - Ireland vs Oman
2019-10-21 - international - T20 - male - 1199515 - Bermuda vs Kenya
2019-10-21 - international - T20 - male - 1199516 - Canada vs Nigeria
2019-10-20 - international - T20 - male - 1199508 - Namibia vs Papua New Guinea
2019-10-20 - international - T20 - male - 1199509 - Canada vs Jersey
2019-10-20 - international - T20 - male - 1199510 - Bermuda vs Singapore
2019-10-20 - international - T20 - male - 1199511 - Hong Kong vs Oman
2019-10-19 - international - T20 - male - 1199503 - Bermuda vs Papua New Guinea
2019-10-19 - international - T20 - male - 1199504 - Jersey vs Nigeria
2019-10-19 - international - T20 - male - 1199505 - Namibia vs Netherlands
2019-10-19 - international - T20 - male - 1199506 - Kenya vs Scotland
2019-10-19 - international - T20 - male - 1199507 - United Arab Emirates vs Ireland
2019-10-18 - international - T20 - male - 1199499 - Scotland vs Singapore
2019-10-18 - international - T20 - male - 1199500 - Hong Kong vs Ireland
2019-10-18 - international - T20 - male - 1199501 - Kenya vs Netherlands
2019-10-18 - international - T20 - male - 1199502 - United Arab Emirates vs Oman
2019-10-10 - international - T20 - male - 1197528 - Hong Kong vs Netherlands
2019-10-10 - international - T20 - male - 1197529 - Oman vs Nepal
2019-10-09 - international - T20 - male - 1197526 - Ireland vs Nepal
2019-10-09 - international - T20 - male - 1197527 - Oman vs Netherlands
2019-10-09 - international - T20 - male - 1198491 - Pakistan vs Sri Lanka
2019-10-07 - international - T20 - male - 1197524 - Nepal vs Netherlands
2019-10-07 - international - T20 - male - 1197525 - Hong Kong vs Ireland
2019-10-07 - international - T20 - male - 1198490 - Pakistan vs Sri Lanka
2019-10-06 - international - T20 - male - 1197522 - Oman vs Ireland
2019-10-06 - international - T20 - male - 1197523 - Hong Kong vs Nepal
2019-10-05 - international - T20 - male - 1197521 - Ireland vs Netherlands
2019-10-05 - international - T20 - male - 1198489 - Pakistan vs Sri Lanka
2019-10-04 - international - T20 - male - 1202011 - Malaysia vs Vanuatu
2019-10-03 - international - T20 - male - 1201685 - Singapore vs Zimbabwe
2019-10-03 - international - T20 - male - 1202010 - Malaysia vs Vanuatu
2019-10-02 - international - T20 - male - 1202009 - Malaysia vs Vanuatu
2019-10-01 - international - T20 - male - 1201683 - Nepal vs Zimbabwe
2019-10-01 - international - T20 - male - 1202008 - Malaysia vs Vanuatu
2019-09-29 - international - T20 - male - 1201682 - Singapore vs Zimbabwe
2019-09-29 - international - T20 - male - 1202007 - Malaysia vs Vanuatu
2019-09-28 - international - T20 - male - 1201681 - Singapore vs Nepal
2019-09-27 - international - T20 - male - 1201680 - Nepal vs Zimbabwe
2019-09-22 - international - T20 - male - 1187006 - India vs South Africa
2019-09-21 - international - T20 - male - 1197145 - Bangladesh vs Afghanistan
2019-09-20 - international - T20 - male - 1197144 - Afghanistan vs Zimbabwe
2019-09-19 - international - T20 - male - 1200428 - Netherlands vs Scotland
2019-09-18 - international - T20 - male - 1187005 - India vs South Africa
2019-09-18 - international - T20 - male - 1197143 - Bangladesh vs Zimbabwe
2019-09-18 - international - T20 - male - 1200427 - Ireland vs Netherlands
2019-09-17 - international - T20 - male - 1200426 - Ireland vs Scotland
2019-09-16 - international - T20 - male - 1200425 - Netherlands vs Scotland
2019-09-15 - international - T20 - male - 1197142 - Bangladesh vs Afghanistan
2019-09-14 - international - T20 - male - 1197141 - Afghanistan vs Zimbabwe
2019-09-13 - international - T20 - male - 1197140 - Bangladesh vs Zimbabwe
2019-09-06 - international - T20 - male - 1192877 - Sri Lanka vs New Zealand
2019-09-03 - international - T20 - male - 1192876 - Sri Lanka vs New Zealand
2019-09-01 - international - T20 - male - 1192875 - Sri Lanka vs New Zealand
2019-08-25 - international - T20 - male - 1197406 - Canada vs United States of America
2019-08-25 - international - T20 - male - 1197407 - Bermuda vs Cayman Islands
2019-08-24 - international - T20 - male - 1197404 - Cayman Islands vs United States of America
2019-08-23 - international - T20 - male - 1197510 - Namibia vs Botswana
2019-08-22 - international - T20 - male - 1197402 - Canada vs Cayman Islands
2019-08-22 - international - T20 - male - 1197403 - United States of America vs Bermuda
2019-08-22 - international - T20 - male - 1197509 - Namibia vs Botswana
2019-08-21 - international - T20 - male - 1197400 - Bermuda vs Cayman Islands
2019-08-21 - international - T20 - male - 1197401 - Canada vs United States of America
2019-08-20 - international - T20 - male - 1197508 - Namibia vs Botswana
2019-08-19 - international - T20 - male - 1197398 - Bermuda vs Canada
2019-08-19 - international - T20 - male - 1197399 - Cayman Islands vs United States of America
2019-08-19 - international - T20 - male - 1197507 - Namibia vs Botswana
2019-08-18 - international - T20 - male - 1197396 - Bermuda vs United States of America
2019-08-18 - international - T20 - male - 1197397 - Canada vs Cayman Islands
2019-08-08 - international - T20 - male - 1191008 - Netherlands vs United Arab Emirates
2019-08-06 - international - T20 - male - 1188623 - West Indies vs India
2019-08-05 - international - T20 - male - 1191006 - Netherlands vs United Arab Emirates
2019-08-04 - international - T20 - male - 1188622 - India vs West Indies
2019-08-03 - international - T20 - male - 1188621 - India vs West Indies
2019-07-28 - international - T20 - male - 1190776 - Singapore vs Nepal
2019-07-27 - international - T20 - male - 1190774 - Kuwait vs Nepal
2019-07-27 - international - T20 - male - 1190775 - Malaysia vs Qatar
2019-07-26 - international - T20 - male - 1190772 - Kuwait vs Qatar
2019-07-26 - international - T20 - male - 1190773 - Singapore vs Malaysia
2019-07-24 - international - T20 - male - 1190771 - Malaysia vs Nepal
2019-07-23 - international - T20 - male - 1190769 - Nepal vs Qatar
2019-07-22 - international - T20 - male - 1190767 - Singapore vs Qatar
2019-07-22 - international - T20 - male - 1190768 - Kuwait vs Malaysia
2019-07-14 - international - T20 - male - 1168522 - Ireland vs Zimbabwe
2019-07-14 - international - T20 - male - 1192224 - Malaysia vs Nepal
2019-07-13 - international - T20 - male - 1192223 - Malaysia vs Nepal
2019-07-12 - international - T20 - male - 1168521 - Ireland vs Zimbabwe
2019-06-29 - international - T20 - male - 1186493 - Maldives vs Thailand
2019-06-28 - international - T20 - male - 1186492 - Malaysia vs Maldives
2019-06-27 - international - T20 - male - 1186491 - Malaysia vs Thailand
2019-06-26 - international - T20 - male - 1186490 - Maldives vs Thailand
2019-06-25 - international - T20 - male - 1188380 - Netherlands vs Zimbabwe
2019-06-24 - international - T20 - male - 1186488 - Malaysia vs Thailand
2019-06-23 - international - T20 - male - 1188379 - Netherlands vs Zimbabwe
2019-06-20 - international - T20 - male - 1185188 - Germany vs Norway
2019-06-20 - international - T20 - male - 1185190 - Germany vs Jersey
2019-06-20 - international - T20 - male - 1189743 - Guernsey vs Denmark
2019-06-20 - international - T20 - male - 1189744 - Denmark vs Italy
2019-06-19 - international - T20 - male - 1185191 - Guernsey vs Norway
2019-06-19 - international - T20 - male - 1185192 - Italy vs Jersey
2019-06-19 - international - T20 - male - 1185193 - Denmark vs Germany
2019-06-18 - international - T20 - male - 1185187 - Guernsey vs Denmark
2019-06-17 - international - T20 - male - 1185182 - Denmark vs Norway
2019-06-16 - international - T20 - male - 1185184 - Denmark vs Jersey
2019-06-16 - international - T20 - male - 1185185 - Guernsey vs Italy
2019-06-16 - international - T20 - male - 1185186 - Jersey vs Norway
2019-06-15 - international - T20 - male - 1185181 - Guernsey vs Germany
2019-05-25 - international - T20 - male - 1178996 - Germany vs Italy
2019-05-23 - international - T20 - male - 1184266 - Uganda vs Ghana
2019-05-22 - international - T20 - male - 1184900 - Ghana vs Nigeria
2019-05-22 - international - T20 - male - 1184901 - Botswana vs Namibia
2019-05-22 - international - T20 - male - 1184902 - Uganda vs Kenya
2019-05-21 - international - T20 - male - 1184261 - Ghana vs Kenya
2019-05-21 - international - T20 - male - 1184262 - Uganda vs Namibia
2019-05-21 - international - T20 - male - 1184263 - Botswana vs Nigeria
2019-05-20 - international - T20 - male - 1184258 - Ghana vs Namibia
2019-05-20 - international - T20 - male - 1184260 - Uganda vs Botswana
2019-05-05 - international - T20 - male - 1152840 - England vs Pakistan
2019-03-24 - international - T20 - male - 1144174 - South Africa vs Sri Lanka
2019-03-24 - international - T20 - male - 1176796 - Philippines vs Vanuatu
2019-03-24 - international - T20 - male - 1176797 - Papua New Guinea vs Vanuatu
2019-03-23 - international - T20 - male - 1176794 - Philippines vs Vanuatu
2019-03-23 - international - T20 - male - 1176795 - Papua New Guinea vs Philippines
2019-03-22 - international - T20 - male - 1144173 - South Africa vs Sri Lanka
2019-03-22 - international - T20 - male - 1176792 - Papua New Guinea vs Philippines
2019-03-22 - international - T20 - male - 1176793 - Papua New Guinea vs Vanuatu
2019-03-19 - international - T20 - male - 1144172 - South Africa vs Sri Lanka
2019-03-16 - international - T20 - male - 1177485 - United Arab Emirates vs United States of America
2019-03-15 - international - T20 - male - 1177484 - United Arab Emirates vs United States of America
2019-03-10 - international - T20 - male - 1158073 - West Indies vs England
2019-03-08 - international - T20 - male - 1158072 - West Indies vs England
2019-03-05 - international - T20 - male - 1158071 - West Indies vs England
2019-02-27 - international - T20 - male - 1168248 - India vs Australia
2019-02-24 - international - T20 - male - 1168114 - Afghanistan vs Ireland
2019-02-24 - international - T20 - male - 1168247 - India vs Australia
2019-02-23 - international - T20 - male - 1168113 - Afghanistan vs Ireland
2019-02-21 - international - T20 - male - 1168112 - Afghanistan vs Ireland
2019-02-17 - international - T20 - male - 1172509 - Ireland vs Netherlands
2019-02-17 - international - T20 - male - 1172510 - Oman vs Scotland
2019-02-15 - international - T20 - male - 1172507 - Oman vs Netherlands
2019-02-15 - international - T20 - male - 1172508 - Ireland vs Scotland
2019-02-13 - international - T20 - male - 1172505 - Netherlands vs Scotland
2019-02-13 - international - T20 - male - 1172506 - Oman vs Ireland
2019-02-10 - international - T20 - male - 1153698 - New Zealand vs India
2019-02-08 - international - T20 - male - 1153697 - New Zealand vs India
2019-02-06 - international - T20 - male - 1144163 - South Africa vs Pakistan
2019-02-06 - international - T20 - male - 1153696 - New Zealand vs India
2019-02-03 - international - T20 - male - 1144162 - South Africa vs Pakistan
2019-02-03 - international - T20 - male - 1170459 - United Arab Emirates vs Nepal
2019-02-01 - international - T20 - male - 1144161 - South Africa vs Pakistan
2019-02-01 - international - T20 - male - 1170458 - United Arab Emirates vs Nepal
2019-01-31 - international - T20 - male - 1170457 - United Arab Emirates vs Nepal
2019-01-11 - international - T20 - male - 1153843 - New Zealand vs Sri Lanka
2018-12-22 - international - T20 - male - 1153319 - Bangladesh vs West Indies
2018-12-20 - international - T20 - male - 1153318 - Bangladesh vs West Indies
2018-12-17 - international - T20 - male - 1153317 - Bangladesh vs West Indies
2018-11-25 - international - T20 - male - 1144992 - Australia vs India
2018-11-23 - international - T20 - male - 1144991 - Australia vs India
2018-11-21 - international - T20 - male - 1144990 - Australia vs India
2018-11-17 - international - T20 - male - 1144989 - South Africa vs Australia
2018-11-11 - international - T20 - male - 1157761 - West Indies vs India
2018-11-06 - international - T20 - male - 1157760 - India vs West Indies
2018-11-04 - international - T20 - male - 1157377 - Pakistan vs New Zealand
2018-11-04 - international - T20 - male - 1157759 - West Indies vs India
2018-11-02 - international - T20 - male - 1157376 - New Zealand vs Pakistan
2018-10-31 - international - T20 - male - 1157375 - Pakistan vs New Zealand
2018-10-28 - international - T20 - male - 1157374 - Pakistan vs Australia
2018-10-27 - international - T20 - male - 1140384 - England vs Sri Lanka
2018-10-26 - international - T20 - male - 1157373 - Pakistan vs Australia
2018-10-24 - international - T20 - male - 1157372 - Pakistan vs Australia
2018-10-22 - international - T20 - male - 1162727 - United Arab Emirates vs Australia
2018-10-12 - international - T20 - male - 1144150 - Zimbabwe vs South Africa
2018-10-09 - international - T20 - male - 1144149 - South Africa vs Zimbabwe
2018-08-22 - international - T20 - male - 1150144 - Afghanistan vs Ireland
2018-08-20 - international - T20 - male - 1150143 - Afghanistan vs Ireland
2018-08-14 - international - T20 - male - 1142589 - South Africa vs Sri Lanka
2018-08-05 - international - T20 - male - 1146725 - Bangladesh vs West Indies
2018-08-04 - international - T20 - male - 1146724 - Bangladesh vs West Indies
2018-07-31 - international - T20 - male - 1146723 - Bangladesh vs West Indies
2018-07-29 - international - T20 - male - 1141835 - Netherlands vs Nepal
2018-07-08 - international - T20 - male - 1119545 - England vs India
2018-07-08 - international - T20 - male - 1142919 - Australia vs Pakistan
2018-07-06 - international - T20 - male - 1119544 - India vs England
2018-07-06 - international - T20 - male - 1142918 - Zimbabwe vs Australia
2018-07-05 - international - T20 - male - 1142917 - Pakistan vs Australia
2018-07-04 - international - T20 - male - 1142916 - Zimbabwe vs Pakistan
2018-07-03 - international - T20 - male - 1119543 - England vs India
2018-07-03 - international - T20 - male - 1142915 - Australia vs Zimbabwe
2018-07-02 - international - T20 - male - 1142914 - Pakistan vs Australia
2018-07-01 - international - T20 - male - 1142913 - Pakistan vs Zimbabwe
2018-06-29 - international - T20 - male - 1140993 - India vs Ireland
2018-06-27 - international - T20 - male - 1119542 - England vs Australia
2018-06-27 - international - T20 - male - 1140992 - India vs Ireland
2018-06-20 - international - T20 - male - 1142506 - Scotland vs Netherlands
2018-06-19 - international - T20 - male - 1142505 - Netherlands vs Scotland
2018-06-17 - international - T20 - male - 1142504 - Scotland vs Ireland
2018-06-16 - international - T20 - male - 1142503 - Ireland vs Scotland
2018-06-13 - international - T20 - male - 1127301 - Pakistan vs Scotland
2018-06-13 - international - T20 - male - 1142502 - Ireland vs Netherlands
2018-06-12 - international - T20 - male - 1127300 - Pakistan vs Scotland
2018-06-12 - international - T20 - male - 1142501 - Netherlands vs Ireland
2018-06-07 - international - T20 - male - 1145984 - Afghanistan vs Bangladesh
2018-06-05 - international - T20 - male - 1145983 - Bangladesh vs Afghanistan
2018-05-31 - international - T20 - male - 1141232 - West Indies vs ICC World XI
2018-04-03 - international - T20 - male - 1140071 - West Indies vs Pakistan
2018-04-02 - international - T20 - male - 1140070 - Pakistan vs West Indies
2018-04-01 - international - T20 - male - 1140069 - Pakistan vs West Indies
2018-03-18 - international - T20 - male - 1133823 - Bangladesh vs India
2018-03-16 - international - T20 - male - 1133822 - Sri Lanka vs Bangladesh
2018-03-14 - international - T20 - male - 1133821 - India vs Bangladesh
2018-03-12 - international - T20 - male - 1133820 - Sri Lanka vs India
2018-03-10 - international - T20 - male - 1133819 - Sri Lanka vs Bangladesh
2018-03-08 - international - T20 - male - 1133818 - Bangladesh vs India
2018-03-06 - international - T20 - male - 1133817 - India vs Sri Lanka
2018-02-24 - international - T20 - male - 1122287 - India vs South Africa
2018-02-21 - international - T20 - male - 1072322 - New Zealand vs Australia
2018-02-21 - international - T20 - male - 1122286 - India vs South Africa
2018-02-18 - international - T20 - male - 1072321 - England vs New Zealand
2018-02-18 - international - T20 - male - 1122285 - India vs South Africa
2018-02-18 - international - T20 - male - 1130747 - Sri Lanka vs Bangladesh
2018-02-16 - international - T20 - male - 1072320 - New Zealand vs Australia
2018-02-15 - international - T20 - male - 1130746 - Bangladesh vs Sri Lanka
2018-02-13 - international - T20 - male - 1072319 - New Zealand vs England
2018-02-10 - international - T20 - male - 1072318 - England vs Australia
2018-02-07 - international - T20 - male - 1072317 - England vs Australia
2018-02-06 - international - T20 - male - 1134032 - Afghanistan vs Zimbabwe
2018-02-05 - international - T20 - male - 1134031 - Zimbabwe vs Afghanistan
2018-02-03 - international - T20 - male - 1072316 - New Zealand vs Australia
2018-01-28 - international - T20 - male - 1115809 - Pakistan vs New Zealand
2018-01-25 - international - T20 - male - 1115808 - Pakistan vs New Zealand
2018-01-22 - international - T20 - male - 1115807 - Pakistan vs New Zealand
2018-01-03 - international - T20 - male - 1115800 - New Zealand vs West Indies
2018-01-01 - international - T20 - male - 1115799 - New Zealand vs West Indies
2017-12-29 - international - T20 - male - 1115798 - New Zealand vs West Indies
2017-12-24 - international - T20 - male - 1122731 - Sri Lanka vs India
2017-12-22 - international - T20 - male - 1122730 - India vs Sri Lanka
2017-12-20 - international - T20 - male - 1122729 - India vs Sri Lanka
2017-11-07 - international - T20 - male - 1120095 - India vs New Zealand
2017-11-04 - international - T20 - male - 1120094 - New Zealand vs India
2017-11-01 - international - T20 - male - 1120093 - India vs New Zealand
2017-10-29 - international - T20 - male - 1075508 - South Africa vs Bangladesh
2017-10-29 - international - T20 - male - 1120293 - Pakistan vs Sri Lanka
2017-10-27 - international - T20 - male - 1120292 - Sri Lanka vs Pakistan
2017-10-26 - international - T20 - male - 1075507 - South Africa vs Bangladesh
2017-10-26 - international - T20 - male - 1120291 - Sri Lanka vs Pakistan
2017-10-10 - international - T20 - male - 1119502 - India vs Australia
2017-10-07 - international - T20 - male - 1119501 - Australia vs India
2017-09-16 - international - T20 - male - 1031665 - West Indies vs England
2017-09-15 - international - T20 - male - 1117824 - Pakistan vs ICC World XI
2017-09-13 - international - T20 - male - 1117822 - Pakistan vs ICC World XI
2017-09-12 - international - T20 - male - 1117821 - Pakistan vs ICC World XI
2017-09-06 - international - T20 - male - 1109610 - Sri Lanka vs India
2017-07-09 - international - T20 - male - 1098211 - West Indies vs India
2017-06-25 - international - T20 - male - 1031435 - England vs South Africa
2017-06-23 - international - T20 - male - 1031433 - England vs South Africa
2017-06-21 - international - T20 - male - 1031431 - England vs South Africa
2017-06-05 - international - T20 - male - 1089778 - West Indies vs Afghanistan
2017-06-03 - international - T20 - male - 1089777 - West Indies vs Afghanistan
2017-06-02 - international - T20 - male - 1089776 - West Indies vs Afghanistan
2017-04-14 - international - T20 - male - 1089203 - United Arab Emirates vs Papua New Guinea
2017-04-14 - international - T20 - male - 1089243 - United Arab Emirates vs Papua New Guinea
2017-04-12 - international - T20 - male - 1089202 - United Arab Emirates vs Papua New Guinea
2017-04-06 - international - T20 - male - 1083450 - Sri Lanka vs Bangladesh
2017-04-04 - international - T20 - male - 1083449 - Sri Lanka vs Bangladesh
2017-04-02 - international - T20 - male - 1085496 - West Indies vs Pakistan
2017-04-01 - international - T20 - male - 1085495 - West Indies vs Pakistan
2017-03-30 - international - T20 - male - 1077948 - West Indies vs Pakistan
2017-03-26 - international - T20 - male - 1077947 - West Indies vs Pakistan
2017-03-12 - international - T20 - male - 1040489 - Afghanistan vs Ireland
2017-03-10 - international - T20 - male - 1040487 - Afghanistan vs Ireland
2017-03-08 - international - T20 - male - 1040485 - Afghanistan vs Ireland
2017-02-22 - international - T20 - male - 1001353 - Australia vs Sri Lanka
2017-02-19 - international - T20 - male - 1001351 - Australia vs Sri Lanka
2017-02-17 - international - T20 - male - 1001349 - Australia vs Sri Lanka
2017-02-17 - international - T20 - male - 1020029 - New Zealand vs South Africa
2017-02-01 - international - T20 - male - 1034829 - India vs England
2017-01-29 - international - T20 - male - 1034827 - India vs England
2017-01-26 - international - T20 - male - 1034825 - India vs England
2017-01-25 - international - T20 - male - 936157 - South Africa vs Sri Lanka
2017-01-22 - international - T20 - male - 936155 - South Africa vs Sri Lanka
2017-01-20 - international - T20 - male - 1074969 - Afghanistan vs Oman
2017-01-20 - international - T20 - male - 1074970 - Ireland vs Scotland
2017-01-20 - international - T20 - male - 1074971 - Afghanistan vs Ireland
2017-01-20 - international - T20 - male - 936153 - South Africa vs Sri Lanka
2017-01-19 - international - T20 - male - 1074968 - Oman vs Scotland
2017-01-18 - international - T20 - male - 1074965 - United Arab Emirates vs Ireland
2017-01-18 - international - T20 - male - 1074966 - Hong Kong vs Netherlands
2017-01-17 - international - T20 - male - 1074964 - Netherlands vs Scotland
2017-01-16 - international - T20 - male - 1074961 - Hong Kong vs Oman
2017-01-16 - international - T20 - male - 1074962 - United Arab Emirates vs Afghanistan
2017-01-15 - international - T20 - male - 1074959 - Netherlands vs Oman
2017-01-14 - international - T20 - male - 1074957 - Hong Kong vs Scotland
2017-01-14 - international - T20 - male - 1074958 - Afghanistan vs Ireland
2017-01-08 - international - T20 - male - 1019983 - New Zealand vs Bangladesh
2017-01-06 - international - T20 - male - 1019981 - New Zealand vs Bangladesh
2017-01-03 - international - T20 - male - 1019979 - New Zealand vs Bangladesh
2016-12-18 - international - T20 - male - 1072208 - United Arab Emirates vs Afghanistan
2016-12-16 - international - T20 - male - 1072207 - United Arab Emirates vs Afghanistan
2016-12-14 - international - T20 - male - 1072206 - United Arab Emirates vs Afghanistan
2016-09-27 - international - T20 - male - 1050221 - Pakistan vs West Indies
2016-09-24 - international - T20 - male - 1050219 - Pakistan vs West Indies
2016-09-23 - international - T20 - male - 1050217 - Pakistan vs West Indies
2016-09-09 - international - T20 - male - 995469 - Sri Lanka vs Australia
2016-09-07 - international - T20 - male - 913663 - England vs Pakistan
2016-09-06 - international - T20 - male - 995467 - Sri Lanka vs Australia
2016-09-05 - international - T20 - male - 1004729 - Ireland vs Hong Kong
2016-08-28 - international - T20 - male - 1041617 - India vs West Indies
2016-08-27 - international - T20 - male - 1041615 - India vs West Indies
2016-07-05 - international - T20 - male - 913633 - England vs Sri Lanka
2016-06-22 - international - T20 - male - 1007659 - Zimbabwe vs India
2016-06-20 - international - T20 - male - 1007657 - Zimbabwe vs India
2016-06-18 - international - T20 - male - 1007655 - Zimbabwe vs India
2016-04-03 - international - T20 - male - 951373 - England vs West Indies
2016-03-31 - international - T20 - male - 951371 - India vs West Indies
2016-03-30 - international - T20 - male - 951369 - England vs New Zealand
2016-03-28 - international - T20 - male - 951367 - South Africa vs Sri Lanka
2016-03-27 - international - T20 - male - 951363 - India vs Australia
2016-03-27 - international - T20 - male - 951365 - Afghanistan vs West Indies
2016-03-26 - international - T20 - male - 951359 - Bangladesh vs New Zealand
2016-03-26 - international - T20 - male - 951361 - England vs Sri Lanka
2016-03-25 - international - T20 - male - 951355 - Australia vs Pakistan
2016-03-25 - international - T20 - male - 951357 - South Africa vs West Indies
2016-03-23 - international - T20 - male - 951351 - Afghanistan vs England
2016-03-23 - international - T20 - male - 951353 - India vs Bangladesh
2016-03-22 - international - T20 - male - 951349 - New Zealand vs Pakistan
2016-03-21 - international - T20 - male - 951347 - Australia vs Bangladesh
2016-03-20 - international - T20 - male - 951343 - Afghanistan vs South Africa
2016-03-20 - international - T20 - male - 951345 - Sri Lanka vs West Indies
2016-03-19 - international - T20 - male - 951341 - India vs Pakistan
2016-03-18 - international - T20 - male - 951337 - Australia vs New Zealand
2016-03-18 - international - T20 - male - 951339 - England vs South Africa
2016-03-17 - international - T20 - male - 951335 - Afghanistan vs Sri Lanka
2016-03-16 - international - T20 - male - 951331 - England vs West Indies
2016-03-16 - international - T20 - male - 951333 - Bangladesh vs Pakistan
2016-03-15 - international - T20 - male - 951329 - India vs New Zealand
2016-03-13 - international - T20 - male - 951325 - Ireland vs Netherlands
2016-03-13 - international - T20 - male - 951327 - Bangladesh vs Oman
2016-03-12 - international - T20 - male - 951321 - Afghanistan vs Zimbabwe
2016-03-12 - international - T20 - male - 951323 - Hong Kong vs Scotland
2016-03-11 - international - T20 - male - 951319 - Bangladesh vs Ireland
2016-03-10 - international - T20 - male - 951313 - Scotland vs Zimbabwe
2016-03-10 - international - T20 - male - 951315 - Afghanistan vs Hong Kong
2016-03-09 - international - T20 - male - 884351 - South Africa vs Australia
2016-03-09 - international - T20 - male - 951309 - Bangladesh vs Netherlands
2016-03-09 - international - T20 - male - 951311 - Ireland vs Oman
2016-03-08 - international - T20 - male - 951305 - Hong Kong vs Zimbabwe
2016-03-08 - international - T20 - male - 951307 - Afghanistan vs Scotland
2016-03-06 - international - T20 - male - 884349 - South Africa vs Australia
2016-03-06 - international - T20 - male - 966765 - Bangladesh vs India
2016-03-04 - international - T20 - male - 884347 - South Africa vs Australia
2016-03-04 - international - T20 - male - 966763 - Pakistan vs Sri Lanka
2016-03-03 - international - T20 - male - 966761 - India vs United Arab Emirates
2016-03-02 - international - T20 - male - 966759 - Bangladesh vs Pakistan
2016-03-01 - international - T20 - male - 966757 - India vs Sri Lanka
2016-02-29 - international - T20 - male - 966755 - Pakistan vs United Arab Emirates
2016-02-28 - international - T20 - male - 966753 - Bangladesh vs Sri Lanka
2016-02-27 - international - T20 - male - 966751 - India vs Pakistan
2016-02-26 - international - T20 - male - 966749 - Bangladesh vs United Arab Emirates
2016-02-25 - international - T20 - male - 966747 - Sri Lanka vs United Arab Emirates
2016-02-24 - international - T20 - male - 966745 - India vs Bangladesh
2016-02-22 - international - T20 - male - 966741 - Afghanistan vs Hong Kong
2016-02-22 - international - T20 - male - 966743 - Oman vs United Arab Emirates
2016-02-21 - international - T20 - male - 800481 - South Africa vs England
2016-02-21 - international - T20 - male - 966739 - Hong Kong vs United Arab Emirates
2016-02-20 - international - T20 - male - 966737 - Afghanistan vs Oman
2016-02-19 - international - T20 - male - 800479 - South Africa vs England
2016-02-19 - international - T20 - male - 966713 - Afghanistan vs United Arab Emirates
2016-02-19 - international - T20 - male - 966735 - Hong Kong vs Oman
2016-02-16 - international - T20 - male - 954743 - United Arab Emirates vs Ireland
2016-02-14 - international - T20 - male - 954741 - United Arab Emirates vs Ireland
2016-02-14 - international - T20 - male - 963701 - India vs Sri Lanka
2016-02-12 - international - T20 - male - 963699 - India vs Sri Lanka
2016-02-09 - international - T20 - male - 954737 - Ireland vs Papua New Guinea
2016-02-09 - international - T20 - male - 963697 - India vs Sri Lanka
2016-02-07 - international - T20 - male - 954735 - Ireland vs Papua New Guinea
2016-02-04 - international - T20 - male - 966373 - United Arab Emirates vs Scotland
2016-02-03 - international - T20 - male - 967081 - United Arab Emirates vs Netherlands
2016-01-31 - international - T20 - male - 895821 - Australia vs India
2016-01-31 - international - T20 - male - 953105 - Hong Kong vs Scotland
2016-01-30 - international - T20 - male - 953103 - Hong Kong vs Scotland
2016-01-29 - international - T20 - male - 895819 - Australia vs India
2016-01-26 - international - T20 - male - 895817 - Australia vs India
2016-01-22 - international - T20 - male - 914225 - New Zealand vs Pakistan
2016-01-22 - international - T20 - male - 958421 - Bangladesh vs Zimbabwe
2016-01-20 - international - T20 - male - 958419 - Bangladesh vs Zimbabwe
2016-01-17 - international - T20 - male - 914223 - New Zealand vs Pakistan
2016-01-17 - international - T20 - male - 958417 - Bangladesh vs Zimbabwe
2016-01-15 - international - T20 - male - 914221 - New Zealand vs Pakistan
2016-01-15 - international - T20 - male - 958415 - Bangladesh vs Zimbabwe
2016-01-10 - international - T20 - male - 914219 - New Zealand vs Sri Lanka
2016-01-10 - international - T20 - male - 953347 - Afghanistan vs Zimbabwe
2016-01-08 - international - T20 - male - 953345 - Afghanistan vs Zimbabwe
2016-01-07 - international - T20 - male - 914217 - New Zealand vs Sri Lanka
2015-11-30 - international - T20 - male - 902653 - England vs Pakistan
2015-11-30 - international - T20 - male - 930585 - Afghanistan vs Oman
2015-11-27 - international - T20 - male - 902651 - England vs Pakistan
2015-11-26 - international - T20 - male - 902649 - England vs Pakistan
2015-11-26 - international - T20 - male - 930579 - Hong Kong vs Oman
2015-11-25 - international - T20 - male - 930577 - Hong Kong vs Oman
2015-11-22 - international - T20 - male - 930573 - United Arab Emirates vs Oman
2015-11-21 - international - T20 - male - 930575 - Hong Kong vs Oman
2015-11-15 - international - T20 - male - 931398 - Bangladesh vs Zimbabwe
2015-11-13 - international - T20 - male - 931396 - Bangladesh vs Zimbabwe
2015-11-11 - international - T20 - male - 915785 - Sri Lanka vs West Indies
2015-11-09 - international - T20 - male - 915783 - Sri Lanka vs West Indies
2015-10-28 - international - T20 - male - 924639 - Zimbabwe vs Afghanistan
2015-10-26 - international - T20 - male - 924637 - Zimbabwe vs Afghanistan
2015-10-05 - international - T20 - male - 903589 - India vs South Africa
2015-10-02 - international - T20 - male - 903587 - India vs South Africa
2015-09-29 - international - T20 - male - 919605 - Zimbabwe vs Pakistan
2015-09-27 - international - T20 - male - 919603 - Zimbabwe vs Pakistan
2015-08-31 - international - T20 - male - 743975 - England vs Australia
2015-08-16 - international - T20 - male - 848841 - South Africa vs New Zealand
2015-08-14 - international - T20 - male - 848839 - South Africa vs New Zealand
2015-08-09 - international - T20 - male - 894293 - Zimbabwe vs New Zealand
2015-08-01 - international - T20 - male - 860281 - Sri Lanka vs Pakistan
2015-07-30 - international - T20 - male - 860279 - Sri Lanka vs Pakistan
2015-07-25 - international - T20 - male - 875549 - Hong Kong vs Scotland
2015-07-25 - international - T20 - male - 875551 - Afghanistan vs Oman
2015-07-25 - international - T20 - male - 875553 - Ireland vs Netherlands
2015-07-23 - international - T20 - male - 875545 - Afghanistan vs Papua New Guinea
2015-07-21 - international - T20 - male - 875541 - Afghanistan vs Hong Kong
2015-07-19 - international - T20 - male - 885971 - Zimbabwe vs India
2015-07-17 - international - T20 - male - 875513 - Nepal vs Papua New Guinea
2015-07-17 - international - T20 - male - 875521 - Ireland vs Hong Kong
2015-07-17 - international - T20 - male - 885969 - Zimbabwe vs India
2015-07-15 - international - T20 - male - 875501 - Ireland vs Papua New Guinea
2015-07-15 - international - T20 - male - 875507 - Hong Kong vs Nepal
2015-07-13 - international - T20 - male - 875491 - Nepal vs Ireland
2015-07-12 - international - T20 - male - 875481 - Netherlands vs United Arab Emirates
2015-07-12 - international - T20 - male - 875485 - Scotland vs Afghanistan
2015-07-11 - international - T20 - male - 875471 - Scotland vs Netherlands
2015-07-10 - international - T20 - male - 875467 - Afghanistan vs United Arab Emirates
2015-07-09 - international - T20 - male - 875457 - Scotland vs United Arab Emirates
2015-07-09 - international - T20 - male - 875459 - Afghanistan vs Netherlands
2015-07-07 - international - T20 - male - 817205 - Bangladesh vs South Africa
2015-07-05 - international - T20 - male - 817203 - Bangladesh vs South Africa
2015-07-02 - international - T20 - male - 883345 - Netherlands vs Nepal
2015-07-01 - international - T20 - male - 883343 - Netherlands vs Nepal
2015-06-23 - international - T20 - male - 743953 - England vs New Zealand
2015-06-20 - international - T20 - male - 889463 - Ireland vs Scotland
2015-05-24 - international - T20 - male - 868725 - Pakistan vs Zimbabwe
2015-05-22 - international - T20 - male - 868723 - Pakistan vs Zimbabwe
2015-04-24 - international - T20 - male - 858491 - Bangladesh vs Pakistan
2015-01-14 - international - T20 - male - 736063 - South Africa vs West Indies
2015-01-11 - international - T20 - male - 722337 - South Africa vs West Indies
2015-01-09 - international - T20 - male - 722335 - South Africa vs West Indies
2014-12-05 - international - T20 - male - 754039 - New Zealand vs Pakistan
2014-12-04 - international - T20 - male - 742617 - New Zealand vs Pakistan
2014-11-24 - international - T20 - male - 802327 - Hong Kong vs Nepal
2014-11-09 - international - T20 - male - 754721 - Australia vs South Africa
2014-11-07 - international - T20 - male - 754719 - Australia vs South Africa
2014-11-05 - international - T20 - male - 754717 - Australia vs South Africa
2014-10-05 - international - T20 - male - 727917 - Australia vs Pakistan
2014-09-07 - international - T20 - male - 667731 - England vs India
2014-08-27 - international - T20 - male - 730293 - West Indies vs Bangladesh
2014-07-06 - international - T20 - male - 730285 - West Indies vs New Zealand
2014-07-05 - international - T20 - male - 730283 - West Indies vs New Zealand
2014-05-20 - international - T20 - male - 667887 - England vs Sri Lanka
2014-04-06 - international - T20 - male - 682965 - India vs Sri Lanka
2014-04-04 - international - T20 - male - 682963 - India vs South Africa
2014-04-03 - international - T20 - male - 682961 - Sri Lanka vs West Indies
2014-04-01 - international - T20 - male - 682957 - Bangladesh vs Australia
2014-04-01 - international - T20 - male - 682959 - Pakistan vs West Indies
2014-03-31 - international - T20 - male - 682953 - England vs Netherlands
2014-03-31 - international - T20 - male - 682955 - New Zealand vs Sri Lanka
2014-03-30 - international - T20 - male - 682949 - Bangladesh vs Pakistan
2014-03-30 - international - T20 - male - 682951 - Australia vs India
2014-03-29 - international - T20 - male - 682945 - Netherlands vs New Zealand
2014-03-29 - international - T20 - male - 682947 - England vs South Africa
2014-03-28 - international - T20 - male - 682941 - Australia vs West Indies
2014-03-28 - international - T20 - male - 682943 - Bangladesh vs India
2014-03-27 - international - T20 - male - 682937 - Netherlands vs South Africa
2014-03-27 - international - T20 - male - 682939 - England vs Sri Lanka
2014-03-25 - international - T20 - male - 682935 - Bangladesh vs West Indies
2014-03-24 - international - T20 - male - 682931 - New Zealand vs South Africa
2014-03-24 - international - T20 - male - 682933 - Netherlands vs Sri Lanka
2014-03-23 - international - T20 - male - 682927 - Australia vs Pakistan
2014-03-23 - international - T20 - male - 682929 - India vs West Indies
2014-03-22 - international - T20 - male - 682923 - South Africa vs Sri Lanka
2014-03-22 - international - T20 - male - 682925 - England vs New Zealand
2014-03-21 - international - T20 - male - 682917 - United Arab Emirates vs Zimbabwe
2014-03-21 - international - T20 - male - 682919 - Ireland vs Netherlands
2014-03-21 - international - T20 - male - 682921 - India vs Pakistan
2014-03-20 - international - T20 - male - 682913 - Afghanistan vs Nepal
2014-03-20 - international - T20 - male - 682915 - Bangladesh vs Hong Kong
2014-03-19 - international - T20 - male - 682909 - Netherlands vs Zimbabwe
2014-03-19 - international - T20 - male - 682911 - Ireland vs United Arab Emirates
2014-03-18 - international - T20 - male - 682905 - Afghanistan vs Hong Kong
2014-03-18 - international - T20 - male - 682907 - Bangladesh vs Nepal
2014-03-17 - international - T20 - male - 682901 - Ireland vs Zimbabwe
2014-03-17 - international - T20 - male - 682903 - Netherlands vs United Arab Emirates
2014-03-16 - international - T20 - male - 682897 - Bangladesh vs Afghanistan
2014-03-16 - international - T20 - male - 682899 - Hong Kong vs Nepal
2014-03-14 - international - T20 - male - 648683 - South Africa vs Australia
2014-03-13 - international - T20 - male - 636538 - West Indies vs England
2014-03-12 - international - T20 - male - 648681 - South Africa vs Australia
2014-03-11 - international - T20 - male - 636537 - West Indies vs England
2014-03-09 - international - T20 - male - 636536 - West Indies vs England
2014-02-21 - international - T20 - male - 702143 - West Indies vs Ireland
2014-02-19 - international - T20 - male - 702141 - West Indies vs Ireland
2014-02-14 - international - T20 - male - 690353 - Bangladesh vs Sri Lanka
2014-02-12 - international - T20 - male - 690351 - Bangladesh vs Sri Lanka
2014-02-02 - international - T20 - male - 636166 - Australia vs England
2014-01-31 - international - T20 - male - 636165 - Australia vs England
2014-01-29 - international - T20 - male - 636164 - Australia vs England
2014-01-15 - international - T20 - male - 661697 - New Zealand vs West Indies
2014-01-11 - international - T20 - male - 661695 - New Zealand vs West Indies
2013-12-13 - international - T20 - male - 657635 - Pakistan vs Sri Lanka
2013-12-11 - international - T20 - male - 657633 - Pakistan vs Sri Lanka
2013-12-08 - international - T20 - male - 657631 - Afghanistan vs Pakistan
2013-11-30 - international - T20 - male - 660235 - Afghanistan vs Ireland
2013-11-28 - international - T20 - male - 660223 - Netherlands vs Scotland
2013-11-26 - international - T20 - male - 660209 - Canada vs Kenya
2013-11-24 - international - T20 - male - 660203 - Afghanistan vs Kenya
2013-11-23 - international - T20 - male - 660185 - Kenya vs Netherlands
2013-11-22 - international - T20 - male - 660173 - Netherlands vs Scotland
2013-11-22 - international - T20 - male - 685729 - South Africa vs Pakistan
2013-11-21 - international - T20 - male - 668969 - Sri Lanka vs New Zealand
2013-11-20 - international - T20 - male - 685727 - South Africa vs Pakistan
2013-11-19 - international - T20 - male - 660149 - Kenya vs Scotland
2013-11-16 - international - T20 - male - 660113 - Canada vs Ireland
2013-11-16 - international - T20 - male - 660123 - Afghanistan vs Scotland
2013-11-15 - international - T20 - male - 649103 - Pakistan vs South Africa
2013-11-15 - international - T20 - male - 660107 - Afghanistan vs Netherlands
2013-11-13 - international - T20 - male - 649101 - Pakistan vs South Africa
2013-11-06 - international - T20 - male - 668959 - Bangladesh vs New Zealand
2013-10-11 - international - T20 - male - 662387 - Afghanistan vs Kenya
2013-10-10 - international - T20 - male - 647247 - India vs Australia
2013-09-30 - international - T20 - male - 662383 - Afghanistan vs Kenya
2013-08-31 - international - T20 - male - 566938 - England vs Australia
2013-08-29 - international - T20 - male - 566937 - England vs Australia
2013-08-24 - international - T20 - male - 659547 - Zimbabwe vs Pakistan
2013-08-23 - international - T20 - male - 659545 - Zimbabwe vs Pakistan
2013-08-06 - international - T20 - male - 635660 - Sri Lanka vs South Africa
2013-08-04 - international - T20 - male - 635659 - Sri Lanka vs South Africa
2013-08-02 - international - T20 - male - 635658 - Sri Lanka vs South Africa
2013-07-28 - international - T20 - male - 645647 - West Indies vs Pakistan
2013-07-27 - international - T20 - male - 645645 - West Indies vs Pakistan
2013-06-27 - international - T20 - male - 566927 - England vs New Zealand
2013-06-25 - international - T20 - male - 566926 - England vs New Zealand
2013-05-12 - international - T20 - male - 623572 - Zimbabwe vs Bangladesh
2013-05-11 - international - T20 - male - 623571 - Zimbabwe vs Bangladesh
2013-04-20 - international - T20 - male - 592276 - Kenya vs Netherlands
2013-04-19 - international - T20 - male - 630951 - Kenya vs Netherlands
2013-03-31 - international - T20 - male - 602477 - Sri Lanka vs Bangladesh
2013-03-16 - international - T20 - male - 592269 - Canada vs Kenya
2013-03-15 - international - T20 - male - 592268 - Canada vs Kenya
2013-03-04 - international - T20 - male - 592273 - Afghanistan vs Scotland
2013-03-03 - international - T20 - male - 567367 - South Africa vs Pakistan
2013-03-03 - international - T20 - male - 592272 - Afghanistan vs Scotland
2013-03-03 - international - T20 - male - 593987 - West Indies vs Zimbabwe
2013-03-02 - international - T20 - male - 593986 - West Indies vs Zimbabwe
2013-02-15 - international - T20 - male - 569239 - New Zealand vs England
2013-02-13 - international - T20 - male - 573027 - Australia vs West Indies
2013-02-12 - international - T20 - male - 569238 - New Zealand vs England
2013-02-09 - international - T20 - male - 569237 - New Zealand vs England
2013-01-28 - international - T20 - male - 573020 - Australia vs Sri Lanka
2013-01-26 - international - T20 - male - 573019 - Australia vs Sri Lanka
2012-12-28 - international - T20 - male - 589307 - India vs Pakistan
2012-12-26 - international - T20 - male - 567355 - South Africa vs New Zealand
2012-12-25 - international - T20 - male - 589306 - India vs Pakistan
2012-12-23 - international - T20 - male - 567354 - South Africa vs New Zealand
2012-12-22 - international - T20 - male - 565811 - India vs England
2012-12-21 - international - T20 - male - 567353 - South Africa vs New Zealand
2012-12-20 - international - T20 - male - 565810 - India vs England
2012-12-10 - international - T20 - male - 587476 - Bangladesh vs West Indies
2012-10-30 - international - T20 - male - 582186 - Sri Lanka vs New Zealand
2012-10-07 - international - T20 - male - 533298 - Sri Lanka vs West Indies
2012-10-05 - international - T20 - male - 533297 - Australia vs West Indies
2012-10-04 - international - T20 - male - 533296 - Sri Lanka vs Pakistan
2012-10-02 - international - T20 - male - 533294 - Australia vs Pakistan
2012-10-02 - international - T20 - male - 533295 - India vs South Africa
2012-10-01 - international - T20 - male - 533292 - New Zealand vs West Indies
2012-10-01 - international - T20 - male - 533293 - Sri Lanka vs England
2012-09-30 - international - T20 - male - 533290 - Australia vs South Africa
2012-09-30 - international - T20 - male - 533291 - India vs Pakistan
2012-09-29 - international - T20 - male - 533288 - England vs New Zealand
2012-09-29 - international - T20 - male - 533289 - Sri Lanka vs West Indies
2012-09-28 - international - T20 - male - 533286 - Pakistan vs South Africa
2012-09-28 - international - T20 - male - 533287 - Australia vs India
2012-09-27 - international - T20 - male - 533284 - Sri Lanka vs New Zealand
2012-09-27 - international - T20 - male - 533285 - England vs West Indies
2012-09-25 - international - T20 - male - 533283 - Bangladesh vs Pakistan
2012-09-24 - international - T20 - male - 533282 - Ireland vs West Indies
2012-09-23 - international - T20 - male - 533280 - New Zealand vs Pakistan
2012-09-23 - international - T20 - male - 533281 - England vs India
2012-09-22 - international - T20 - male - 533278 - Sri Lanka vs South Africa
2012-09-22 - international - T20 - male - 533279 - Australia vs West Indies
2012-09-21 - international - T20 - male - 533276 - Bangladesh vs New Zealand
2012-09-21 - international - T20 - male - 533277 - Afghanistan vs England
2012-09-20 - international - T20 - male - 533275 - South Africa vs Zimbabwe
2012-09-19 - international - T20 - male - 533273 - Australia vs Ireland
2012-09-19 - international - T20 - male - 533274 - Afghanistan vs India
2012-09-18 - international - T20 - male - 533272 - Sri Lanka vs Zimbabwe
2012-09-12 - international - T20 - male - 534235 - England vs South Africa
2012-09-11 - international - T20 - male - 565820 - India vs New Zealand
2012-09-10 - international - T20 - male - 534234 - England vs South Africa
2012-09-10 - international - T20 - male - 571150 - Australia vs Pakistan
2012-09-08 - international - T20 - male - 534233 - England vs South Africa
2012-09-07 - international - T20 - male - 571149 - Australia vs Pakistan
2012-09-05 - international - T20 - male - 571148 - Australia vs Pakistan
2012-08-07 - international - T20 - male - 564786 - Sri Lanka vs India
2012-07-26 - international - T20 - male - 573672 - Netherlands vs Bangladesh
2012-07-25 - international - T20 - male - 567205 - Netherlands vs Bangladesh
2012-07-18 - international - T20 - male - 567071 - Ireland vs Bangladesh
2012-07-01 - international - T20 - male - 560922 - New Zealand vs West Indies
2012-06-30 - international - T20 - male - 560921 - New Zealand vs West Indies
2012-06-24 - international - T20 - male - 534208 - England vs West Indies
2012-06-03 - international - T20 - male - 562438 - Sri Lanka vs Pakistan
2012-06-01 - international - T20 - male - 562437 - Sri Lanka vs Pakistan
2012-03-30 - international - T20 - male - 540174 - West Indies vs Australia
2012-03-30 - international - T20 - male - 556252 - South Africa vs India
2012-03-27 - international - T20 - male - 540173 - West Indies vs Australia
2012-03-24 - international - T20 - male - 546477 - Afghanistan vs Ireland
2012-03-23 - international - T20 - male - 546470 - Ireland vs Netherlands
2012-03-23 - international - T20 - male - 546473 - Canada vs Scotland
2012-03-22 - international - T20 - male - 546462 - Canada vs Ireland
2012-03-18 - international - T20 - male - 546442 - Ireland vs Scotland
2012-03-18 - international - T20 - male - 546443 - Afghanistan vs Canada
2012-03-14 - international - T20 - male - 546414 - Ireland vs Kenya
2012-03-14 - international - T20 - male - 546418 - Afghanistan vs Netherlands
2012-03-13 - international - T20 - male - 546410 - Canada vs Netherlands
2012-02-27 - international - T20 - male - 531637 - England vs Pakistan
2012-02-25 - international - T20 - male - 531636 - England vs Pakistan
2012-02-24 - international - T20 - male - 543885 - Kenya vs Ireland
2012-02-23 - international - T20 - male - 531635 - England vs Pakistan
2012-02-23 - international - T20 - male - 543884 - Kenya vs Ireland
2012-02-22 - international - T20 - male - 520599 - New Zealand vs South Africa
2012-02-22 - international - T20 - male - 543883 - Kenya vs Ireland
2012-02-19 - international - T20 - male - 520598 - New Zealand vs South Africa
2012-02-17 - international - T20 - male - 520597 - New Zealand vs South Africa
2012-02-14 - international - T20 - male - 520596 - New Zealand vs Zimbabwe
2012-02-11 - international - T20 - male - 520595 - New Zealand vs Zimbabwe
2012-02-03 - international - T20 - male - 518955 - Australia vs India
2012-02-01 - international - T20 - male - 518954 - Australia vs India
2011-11-29 - international - T20 - male - 538068 - Bangladesh vs Pakistan
2011-11-25 - international - T20 - male - 530432 - Pakistan vs Sri Lanka
2011-10-29 - international - T20 - male - 521217 - India vs England
2011-10-17 - international - T20 - male - 527013 - Zimbabwe vs New Zealand
2011-10-16 - international - T20 - male - 514024 - South Africa vs Australia
2011-10-15 - international - T20 - male - 527012 - Zimbabwe vs New Zealand
2011-10-13 - international - T20 - male - 514023 - South Africa vs Australia
2011-10-11 - international - T20 - male - 531982 - Bangladesh vs West Indies
2011-09-25 - international - T20 - male - 525817 - England vs West Indies
2011-09-23 - international - T20 - male - 525816 - England vs West Indies
2011-09-18 - international - T20 - male - 523736 - Zimbabwe vs Pakistan
2011-09-16 - international - T20 - male - 523735 - Zimbabwe vs Pakistan
2011-08-31 - international - T20 - male - 474476 - England vs India
2011-08-08 - international - T20 - male - 516205 - Sri Lanka vs Australia
2011-08-06 - international - T20 - male - 516204 - Sri Lanka vs Australia
2011-06-25 - international - T20 - male - 474466 - England vs Sri Lanka
2011-06-04 - international - T20 - male - 489220 - West Indies vs India
2011-04-21 - international - T20 - male - 489212 - West Indies vs Pakistan
2011-01-14 - international - T20 - male - 446961 - Australia vs England
2011-01-12 - international - T20 - male - 446960 - Australia vs England
2011-01-09 - international - T20 - male - 463149 - South Africa vs India
2010-12-30 - international - T20 - male - 473920 - New Zealand vs Pakistan
2010-12-28 - international - T20 - male - 473919 - New Zealand vs Pakistan
2010-12-26 - international - T20 - male - 473918 - New Zealand vs Pakistan
2010-10-31 - international - T20 - male - 446956 - Australia vs Sri Lanka
2010-10-27 - international - T20 - male - 461565 - Pakistan vs South Africa
2010-10-26 - international - T20 - male - 478279 - Pakistan vs South Africa
2010-10-10 - international - T20 - male - 463142 - South Africa vs Zimbabwe
2010-10-08 - international - T20 - male - 463141 - South Africa vs Zimbabwe
2010-09-07 - international - T20 - male - 426418 - England vs Pakistan
2010-09-05 - international - T20 - male - 426417 - England vs Pakistan
2010-07-06 - international - T20 - male - 426393 - Australia vs Pakistan
2010-07-05 - international - T20 - male - 426392 - Australia vs Pakistan
2010-06-13 - international - T20 - male - 452154 - Zimbabwe vs India
2010-06-12 - international - T20 - male - 452153 - Zimbabwe vs India
2010-05-23 - international - T20 - male - 456992 - New Zealand vs Sri Lanka
2010-05-22 - international - T20 - male - 456991 - New Zealand vs Sri Lanka
2010-05-20 - international - T20 - male - 447539 - West Indies vs South Africa
2010-05-19 - international - T20 - male - 439146 - West Indies vs South Africa
2010-05-16 - international - T20 - male - 412703 - Australia vs England
2010-05-14 - international - T20 - male - 412702 - Australia vs Pakistan
2010-05-13 - international - T20 - male - 412701 - England vs Sri Lanka
2010-05-11 - international - T20 - male - 412699 - India vs Sri Lanka
2010-05-11 - international - T20 - male - 412700 - West Indies vs Australia
2010-05-10 - international - T20 - male - 412697 - Pakistan vs South Africa
2010-05-10 - international - T20 - male - 412698 - England vs New Zealand
2010-05-09 - international - T20 - male - 412695 - West Indies vs India
2010-05-09 - international - T20 - male - 412696 - Australia vs Sri Lanka
2010-05-08 - international - T20 - male - 412693 - New Zealand vs Pakistan
2010-05-08 - international - T20 - male - 412694 - England vs South Africa
2010-05-07 - international - T20 - male - 412691 - Australia vs India
2010-05-07 - international - T20 - male - 412692 - West Indies vs Sri Lanka
2010-05-06 - international - T20 - male - 412689 - England vs Pakistan
2010-05-06 - international - T20 - male - 412690 - New Zealand vs South Africa
2010-05-05 - international - T20 - male - 412687 - Afghanistan vs South Africa
2010-05-05 - international - T20 - male - 412688 - Australia vs Bangladesh
2010-05-04 - international - T20 - male - 412681 - England vs Ireland
2010-05-04 - international - T20 - male - 412684 - New Zealand vs Zimbabwe
2010-05-03 - international - T20 - male - 412685 - West Indies vs England
2010-05-03 - international - T20 - male - 412686 - Sri Lanka vs Zimbabwe
2010-05-02 - international - T20 - male - 412682 - India vs South Africa
2010-05-02 - international - T20 - male - 412683 - Australia vs Pakistan
2010-05-01 - international - T20 - male - 412679 - Afghanistan vs India
2010-05-01 - international - T20 - male - 412680 - Bangladesh vs Pakistan
2010-04-30 - international - T20 - male - 412677 - West Indies vs Ireland
2010-04-30 - international - T20 - male - 412678 - New Zealand vs Sri Lanka
2010-02-28 - international - T20 - male - 423788 - New Zealand vs Australia
2010-02-28 - international - T20 - male - 439139 - West Indies vs Zimbabwe
2010-02-26 - international - T20 - male - 423787 - New Zealand vs Australia
2010-02-23 - international - T20 - male - 406198 - Australia vs West Indies
2010-02-21 - international - T20 - male - 406197 - Australia vs West Indies
2010-02-20 - international - T20 - male - 440946 - England vs Pakistan
2010-02-19 - international - T20 - male - 440945 - England vs Pakistan
2010-02-13 - international - T20 - male - 439510 - Ireland vs Netherlands
2010-02-13 - international - T20 - male - 439511 - Afghanistan vs Ireland
2010-02-12 - international - T20 - male - 439507 - Afghanistan vs Netherlands
2010-02-11 - international - T20 - male - 439505 - Ireland vs Scotland
2010-02-10 - international - T20 - male - 439499 - Canada vs Kenya
2010-02-09 - international - T20 - male - 439495 - Afghanistan vs Ireland
2010-02-09 - international - T20 - male - 439497 - Canada vs Netherlands
2010-02-05 - international - T20 - male - 406207 - Australia vs Pakistan
2010-02-03 - international - T20 - male - 423782 - New Zealand vs Bangladesh
2009-12-12 - international - T20 - male - 430885 - India vs Sri Lanka
2009-12-09 - international - T20 - male - 430884 - India vs Sri Lanka
2009-11-15 - international - T20 - male - 387564 - South Africa vs England
2009-11-13 - international - T20 - male - 387563 - South Africa vs England
2009-11-13 - international - T20 - male - 426724 - New Zealand vs Pakistan
2009-11-12 - international - T20 - male - 426723 - New Zealand vs Pakistan
2009-09-04 - international - T20 - male - 403386 - Sri Lanka vs New Zealand
2009-09-02 - international - T20 - male - 403385 - Sri Lanka vs New Zealand
2009-08-30 - international - T20 - male - 350050 - England vs Australia
2009-08-12 - international - T20 - male - 403375 - Sri Lanka vs Pakistan
2009-08-02 - international - T20 - male - 401076 - West Indies vs Bangladesh
2009-06-21 - international - T20 - male - 356017 - Pakistan vs Sri Lanka
2009-06-19 - international - T20 - male - 356016 - Sri Lanka vs West Indies
2009-06-18 - international - T20 - male - 356015 - Pakistan vs South Africa
2009-06-16 - international - T20 - male - 356013 - New Zealand vs Sri Lanka
2009-06-16 - international - T20 - male - 356014 - India vs South Africa
2009-06-15 - international - T20 - male - 356011 - England vs West Indies
2009-06-15 - international - T20 - male - 356012 - Ireland vs Pakistan
2009-06-14 - international - T20 - male - 356009 - Ireland vs Sri Lanka
2009-06-14 - international - T20 - male - 356010 - England vs India
2009-06-13 - international - T20 - male - 356007 - South Africa vs West Indies
2009-06-13 - international - T20 - male - 356008 - New Zealand vs Pakistan
2009-06-12 - international - T20 - male - 356005 - Pakistan vs Sri Lanka
2009-06-12 - international - T20 - male - 356006 - India vs West Indies
2009-06-11 - international - T20 - male - 356003 - Ireland vs New Zealand
2009-06-11 - international - T20 - male - 356004 - England vs South Africa
2009-06-10 - international - T20 - male - 356001 - India vs Ireland
2009-06-10 - international - T20 - male - 356002 - Sri Lanka vs West Indies
2009-06-09 - international - T20 - male - 355999 - Netherlands vs Pakistan
2009-06-09 - international - T20 - male - 356000 - New Zealand vs South Africa
2009-06-08 - international - T20 - male - 355997 - Bangladesh vs Ireland
2009-06-08 - international - T20 - male - 355998 - Australia vs Sri Lanka
2009-06-07 - international - T20 - male - 355995 - Scotland vs South Africa
2009-06-07 - international - T20 - male - 355996 - England vs Pakistan
2009-06-06 - international - T20 - male - 355992 - New Zealand vs Scotland
2009-06-06 - international - T20 - male - 355993 - Australia vs West Indies
2009-06-06 - international - T20 - male - 355994 - Bangladesh vs India
2009-06-05 - international - T20 - male - 355991 - England vs Netherlands
2009-05-07 - international - T20 - male - 392615 - Australia vs Pakistan
2009-03-29 - international - T20 - male - 350476 - South Africa vs Australia
2009-03-27 - international - T20 - male - 350475 - South Africa vs Australia
2009-03-15 - international - T20 - male - 352674 - West Indies vs England
2009-02-27 - international - T20 - male - 366622 - New Zealand vs India
2009-02-25 - international - T20 - male - 386494 - New Zealand vs India
2009-02-15 - international - T20 - male - 351696 - Australia vs New Zealand
2009-02-10 - international - T20 - male - 386535 - Sri Lanka vs India
2009-01-13 - international - T20 - male - 351695 - Australia vs South Africa
2009-01-11 - international - T20 - male - 351694 - Australia vs South Africa
2008-12-28 - international - T20 - male - 366708 - New Zealand vs West Indies
2008-12-26 - international - T20 - male - 366707 - New Zealand vs West Indies
2008-11-05 - international - T20 - male - 350347 - South Africa vs Bangladesh
2008-10-13 - international - T20 - male - 361660 - Pakistan vs Sri Lanka
2008-10-11 - international - T20 - male - 361656 - Pakistan vs Sri Lanka
2008-08-04 - international - T20 - male - 361530 - Ireland vs Kenya
2008-08-04 - international - T20 - male - 361531 - Netherlands vs Scotland
2008-08-03 - international - T20 - male - 354456 - Bermuda vs Scotland
2008-06-20 - international - T20 - male - 319142 - West Indies vs Australia
2008-06-13 - international - T20 - male - 296903 - England vs New Zealand
2008-04-20 - international - T20 - male - 343764 - Pakistan vs Bangladesh
2008-02-07 - international - T20 - male - 300436 - New Zealand vs England
2008-02-05 - international - T20 - male - 300435 - New Zealand vs England
2008-02-01 - international - T20 - male - 291356 - Australia vs India
2008-01-18 - international - T20 - male - 298804 - South Africa vs West Indies
2007-12-16 - international - T20 - male - 319112 - South Africa vs West Indies
2007-12-11 - international - T20 - male - 291343 - Australia vs New Zealand
2007-11-23 - international - T20 - male - 298795 - South Africa vs New Zealand
2007-10-20 - international - T20 - male - 297800 - India vs Australia
2007-09-24 - international - T20 - male - 287879 - India vs Pakistan
2007-09-22 - international - T20 - male - 287877 - New Zealand vs Pakistan
2007-09-22 - international - T20 - male - 287878 - Australia vs India
2007-09-20 - international - T20 - male - 287874 - Australia vs Sri Lanka
2007-09-20 - international - T20 - male - 287875 - Bangladesh vs Pakistan
2007-09-20 - international - T20 - male - 287876 - South Africa vs India
2007-09-19 - international - T20 - male - 287872 - South Africa vs New Zealand
2007-09-19 - international - T20 - male - 287873 - England vs India
2007-09-18 - international - T20 - male - 287869 - England vs New Zealand
2007-09-18 - international - T20 - male - 287870 - Australia vs Pakistan
2007-09-18 - international - T20 - male - 287871 - Bangladesh vs Sri Lanka
2007-09-17 - international - T20 - male - 287868 - Pakistan vs Sri Lanka
2007-09-16 - international - T20 - male - 287865 - India vs New Zealand
2007-09-16 - international - T20 - male - 287866 - Australia vs Bangladesh
2007-09-16 - international - T20 - male - 287867 - South Africa vs England
2007-09-15 - international - T20 - male - 287863 - New Zealand vs Sri Lanka
2007-09-15 - international - T20 - male - 287864 - South Africa vs Bangladesh
2007-09-14 - international - T20 - male - 287860 - Kenya vs Sri Lanka
2007-09-14 - international - T20 - male - 287861 - Australia vs England
2007-09-14 - international - T20 - male - 287862 - India vs Pakistan
2007-09-13 - international - T20 - male - 287857 - Bangladesh vs West Indies
2007-09-13 - international - T20 - male - 287858 - England vs Zimbabwe
2007-09-12 - international - T20 - male - 287854 - Kenya vs New Zealand
2007-09-12 - international - T20 - male - 287855 - Pakistan vs Scotland
2007-09-12 - international - T20 - male - 287856 - Australia vs Zimbabwe
2007-09-11 - international - T20 - male - 287853 - South Africa vs West Indies
2007-09-04 - international - T20 - male - 306991 - Kenya vs Pakistan
2007-09-02 - international - T20 - male - 306989 - Bangladesh vs Pakistan
2007-09-01 - international - T20 - male - 306987 - Kenya vs Bangladesh
2007-06-29 - international - T20 - male - 258464 - England vs West Indies
2007-06-28 - international - T20 - male - 258463 - England vs West Indies
2007-01-09 - international - T20 - male - 249227 - Australia vs England
2006-12-26 - international - T20 - male - 251488 - New Zealand vs Sri Lanka
2006-12-22 - international - T20 - male - 251487 - New Zealand vs Sri Lanka
2006-12-01 - international - T20 - male - 255954 - South Africa vs India
2006-08-28 - international - T20 - male - 225263 - England vs Pakistan
2006-06-15 - international - T20 - male - 225271 - England vs Sri Lanka
2006-02-24 - international - T20 - male - 238195 - South Africa vs Australia
2006-02-16 - international - T20 - male - 237242 - New Zealand vs West Indies
2006-01-09 - international - T20 - male - 226374 - Australia vs South Africa
2005-10-21 - international - T20 - male - 222678 - South Africa vs New Zealand
2005-06-13 - international - T20 - male - 211028 - England vs Australia
2005-02-17 - international - T20 - male - 211048 - New Zealand vs Australia

Further information
-------------------

You can find all of our currently available data at https://cricsheet.org/

You can contact me via the following methods:
  Email  : stephen@cricsheet.org
  Twitter: @cricsheet
