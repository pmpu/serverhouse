#include "opencv2/highgui/highgui.hpp"
#include "opencv2/core/core.hpp"
#include <iostream>
#include <opencv2\highgui\highgui.hpp>
#include <opencv2\imgproc\imgproc.hpp>
#include <opencv\cv.h>

using namespace cv;
using namespace std;


int main()
{
	cout << "Write image name (with format), pls // for example, image.jpg" << endl;
	string imageName;
	string outputImageName;
	cin >> imageName;
	Mat img = imread(imageName, 1);
	//Mat img = img0;
	//resize(img0, img, 640, 480, )
	/*
	Mat grey;

	cvtColor(img, grey, CV_BGR2GRAY);
	Mat sobelx;
	Sobel(grey, sobelx, CV_32F, 1, 0);
	double minVal, maxVal;
	minMaxLoc(sobelx, &minVal, &maxVal); //find minimum and maximum intensities
	Mat draw;
	sobelx.convertTo(draw, CV_8U, 255.0/(maxVal - minVal), -minVal * 255.0/(maxVal - minVal));
	*/
	//imshow("image", draw);
	//imshow("image1", grey);
	//imshow("image2", sobelx);
	Mat img2;
	img2=img;
	int rows = img.rows;
	int cols = img.cols;

	cv::Size s = img.size();
	rows = s.height;
	cols = s.width;
	cout << img.channels();
	for(int x = 0; x < cols; x++)
	{
		for (int y = 0; y < rows; y++)
		{
			/*if (img.at<Vec3b>(y,x).val[0] > img.at<Vec3b>(y,x).val[1] && img.at<Vec3b>(y,x).val[0] > img.at<Vec3b>(y,x).val[2] ) {
				img.at<Vec3b>(y,x).val[0]= 255 ;
				img.at<Vec3b>(y,x).val[1]= 0 ;
				img.at<Vec3b>(y,x).val[2]= 0 ;
			}
			if (img.at<Vec3b>(y,x).val[1] > img.at<Vec3b>(y,x).val[0] && img.at<Vec3b>(y,x).val[1] > img.at<Vec3b>(y,x).val[2] )
			{
				img.at<Vec3b>(y,x).val[0]= 0 ;
				img.at<Vec3b>(y,x).val[1]= 255 ;
				img.at<Vec3b>(y,x).val[2]= 0 ;
			}
			if (img.at<Vec3b>(y,x).val[2] > img.at<Vec3b>(y,x).val[1] && img.at<Vec3b>(y,x).val[2] > img.at<Vec3b>(y,x).val[0] )
			{
				img.at<Vec3b>(y,x).val[0]= 0 ;
				img.at<Vec3b>(y,x).val[1]= 0 ;
				img.at<Vec3b>(y,x).val[2]= 255 ;
			}*/
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
	imshow("res", img);
	//cout << endl << "Name of new image after poster: " << endl;
	//cin >> outputImageName;
	imwrite("result.jpg", img);
	//img.convertTo(img2, CV_8U, 255.0/2 < 128? 0 : 255.0, 255.0/2 > 128? 0 : 255.0); 
	//img2 = img.reshape(2, 0);	
	/*for(int i=0; i < 50; i++)
	{
		img2.row(i) = 104; 
		img2.col(i)=104;
	}
	*/
	//img.row(i)=128; 
	//img = img*img2;

	//cout << draw.row(1);
	
	waitKey(0);
	destroyAllWindows();
	return 0;
}