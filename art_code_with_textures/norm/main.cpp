#include "poster.h"
/*#include "opencv2/highgui/highgui.hpp"
#include "opencv2/core/core.hpp"
#include <iostream>
#include <opencv2\highgui\highgui.hpp>
#include <opencv2\imgproc\imgproc.hpp>
#include <opencv\cv.h>

using namespace cv;
using namespace std;

void img_posterization()
{
	cout << "Write image name (with format), pls // for example, image.jpg" << endl;
	string imageName;
	string outputImageName;
	cin >> imageName;
	
	Mat img = imread(imageName, 1);

	int rows = img.rows;
	int cols = img.cols;

	Size s = img.size();
	rows = s.height;
	cols = s.width;
	cout << img.channels();
	if (rows == 0 || cols == 0)
	{
		cout << "Image is not found" << endl; 
		return;
	}
	for(int x = 0; x < cols; x++)
	{
		for (int y = 0; y < rows; y++)
		{
			if(img.at<Vec3b>(y,x).val[0] < 128)
				img.at<Vec3b>(y,x).val[0] = 0;
			else img.at<Vec3b>(y,x).val[0] = 255;

			if(img.at<Vec3b>(y,x).val[1] < 128)
				img.at<Vec3b>(y,x).val[1] = 0;
			else img.at<Vec3b>(y,x).val[1] = 255;

			if(img.at<Vec3b>(y,x).val[2] < 128)
				img.at<Vec3b>(y,x).val[2] = 0;
			else img.at<Vec3b>(y,x).val[2] = 255;


		}
	}
	imshow("posterizated", img);
	imwrite("posterizated_" + imageName, img);
	
}
*/
int main()
{
	img_posterization();
	//posterizated_cat2 - grey

	waitKey(0);
	destroyAllWindows();
	return 0;
}