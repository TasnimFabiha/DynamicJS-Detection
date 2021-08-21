#DynamicJS-Detection
This repository is the implementation of the basic foundation of an empirical study, 
proposed by [Sebastian et al 2015](https://www.usenix.org/node/190993).

#1.The Empirical Study:

An approach to detect the presence of dynamic JavaScript on any web applications
and finding the exploitation technique is presented in this implementation. Use of dynamic scripts on any 
web applications can lead to
extreme occurrences of information leakage. Cross-Site Script Inclusion (XSSI), is
such kind of security attack, that can be easily done by utilizing the advantage of
using state-dependent dynamic JavaScript on web applications.  An approach
for Bangladeshi dataset is presented here for providing acuity of the occurrences of
dynamic scripts and, determining how these occurrences can lead to severe consequences of information leakage. Keeping the above factors in mind, a methodology
is proposed to experiment an empirical study. This is designed to gain insights into
the prevalence and exploitability of data leakage caused by the use of dynamic script
generation.

#1.1 How the extension works
The overall implementation can be descirbed in the following images. The extension works on the target web application. Collects scripts and sends those to the backend server.

<img src="https://github.com/TasnimFabiha/DynamicJS-Detection/blob/master/ext1.jpg" alt="dynamicJS detection approach" align="center"/>
<p align="center"> Figure 1: Detection Approach in Extension </p>


The server stores all the scripts sources and requests those twice. Once with authentication cookies, once without.
<img src="https://github.com/TasnimFabiha/DynamicJS-Detection/blob/master/ext2.jpg" alt="dynamicJS detection approach" align="center"/>
<p align="center"> Figure 1: Detection Approach in Server-side </p>


The received responses are then compared if those differ. If the responses differ then the corresponding scripts are identified as dynamic
<img src="https://github.com/TasnimFabiha/DynamicJS-Detection/blob/master/compare.jpg" alt="dynamicJS detection approach" align="center"/>
<p align="center"> Figure 1: Detection of Dynamic JS </p>


Thus, this overall approach works.

This approach is tested on Bangladeshi dataset. However, a dymmu dataset is also added to this repository to evaluate the performance of the implemented framework.
