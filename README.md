# ScreenOCR
 
This is a small tool which assists in performing fast OCR (and HTR, if available) by allowing you to select regions of interest directly from your screen. The application will return the selectable text in a new window right near your selected region.

## Requirements

#### Windows (tested on Windows Home 21H1)
#### Net Framework 4.5

 ## Quick Start

1. Run the application: **ScreenOCR.exe**
2. A white window should pop up if this is the first time running it; you'll need to fill
    - **Language**: the language and script you're expecting to use; for example, `en-ma` stands for **English Modern-Antiqua**;
    - **API Key**: this tool performs the OCR/HTR in **overfitted.io**'s cloud infrastructure using the **Glyph** engine; you'll need a key to successfully query images; see the [Get Started](https://overfitted.io/get-started/) section to receive one with some **free credits**.
    - Optionally, check the **launch at startup** box if you feel you'll be using this more often
    - **NOTE:**: if the window doesn't show up or you need to re-open it, use the following 2 shortcuts in this sequence: **[Win]-[Shift]-[Q]** and then **[Shift]-[O]**
3. Press **[Win]-[Shift]-[Q]** to switch to capture mode; your screen should turn darker at this stage.
4. **Draw** a rectangle **using your mouse**
5. Hit the **[↵ Enter]** key to submit the image and await the response
6. Within the recently opened window, copy the text and press **[Esc]** to close it

**To close:** while in capture mode (**[Win]-[Shift]-[Q]**), press **[Shift]-[Esc]** and it should close the entire application. 

## Privacy
 
ScreenOCR uses a **global keyhook**, to record the **[Win]-[Shift]-[Q]** key combination while it is out of focus and switch to capture mode; no other keys are being globally monitored. However, some anti-malware products might find this intrusive and act accordingly. Additionally, the tool implements a **screenshot** taking procedure which might also be considered suspicious due to its common presence in spyware.

To avoid suspicions, the entire code is available in this repository and can easily be verified for any malicious/unintended behaviour.


## Further development

This tool tracks the development process of the overfitted.io API and might change in the future. Hopefully, the code will be refined && improved in time.



