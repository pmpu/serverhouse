#include "opencv2/highgui/highgui.hpp"
#include "opencv2/core/core.hpp"
#include <iostream>
#include <opencv2\highgui\highgui.hpp>
#include <opencv2\imgproc\imgproc.hpp>
#include <opencv\cv.h>

using namespace cv;
using namespace std;

class Colorof{  // don't forget delete this class
private:
	string colorName;
	int colorNumber;
public:
	string getColorName(int colorNumber);
	int getColorNumber(string colorName);
	void setColorName(string NewcolorName);
	void setColorNumber(int NewcolorNumber);

};

void img_posterization();