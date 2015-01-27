#include "poster.h"

void img_posterization()
{
	cout << "Write image name (with format), pls // for example, image.jpg" << endl;
	string imageName;
	string outputImageName;
	cin >> imageName;
	
	Mat img = imread(imageName, 1);

	int rows = img.rows;
	int cols = img.cols;
	int colors_after_poster[8][2][3] = {0};
		// black, blue, green, red,  yellow, margenta, cian, white - min and max
	for (int i = 0; i < 8; i++)
	{
		colors_after_poster[i][0][0] = 255;
		colors_after_poster[i][0][1] = 255;
		colors_after_poster[i][0][2] = 255;

	}
	
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
			int pixtmp[3];
			pixtmp[0] = img.at<Vec3b>(y,x).val[0];
			pixtmp[1] = img.at<Vec3b>(y,x).val[1];
			pixtmp[2] = img.at<Vec3b>(y,x).val[2];

			if(img.at<Vec3b>(y,x).val[0] < 128)
				img.at<Vec3b>(y,x).val[0] = 0;
			else img.at<Vec3b>(y,x).val[0] = 255;

			if(img.at<Vec3b>(y,x).val[1] < 128)
				img.at<Vec3b>(y,x).val[1] = 0;
			else img.at<Vec3b>(y,x).val[1] = 255;

			if(img.at<Vec3b>(y,x).val[2] < 128)
				img.at<Vec3b>(y,x).val[2] = 0;
			else img.at<Vec3b>(y,x).val[2] = 255;

			if (img.at<Vec3b>(y,x).val[0] == 0 && img.at<Vec3b>(y,x).val[1] ==  0 && img.at<Vec3b>(y,x).val[2] == 0) // black
			{
				for (int k = 0; k < 3; k++)
				{
					if (pixtmp[k] < colors_after_poster[0][0][k]) 
						colors_after_poster[0][0][k] = pixtmp[k]; // min
					if (pixtmp[k] > colors_after_poster[0][1][k])
						colors_after_poster[0][1][k] = pixtmp[k]; // max
				}

			}

			// blue
			if (img.at<Vec3b>(y,x).val[0] == 255 && img.at<Vec3b>(y,x).val[1] ==  0 && img.at<Vec3b>(y,x).val[2] == 0) 
			{
				for (int k = 0; k < 3; k++)
				{
					if (pixtmp[k] < colors_after_poster[1][0][k]) 
						colors_after_poster[1][0][k] = pixtmp[k]; // min
					if (pixtmp[k] > colors_after_poster[1][1][k])
						colors_after_poster[1][1][k] = pixtmp[k]; // max
				}

			}

			// green
			if (img.at<Vec3b>(y,x).val[0] == 0 && img.at<Vec3b>(y,x).val[1] ==  255 && img.at<Vec3b>(y,x).val[2] == 0) 
			{
				for (int k = 0; k < 3; k++)
				{
					if (pixtmp[k] < colors_after_poster[2][0][k]) 
						colors_after_poster[2][0][k] = pixtmp[k]; // min
					if (pixtmp[k] > colors_after_poster[2][1][k])
						colors_after_poster[2][1][k] = pixtmp[k]; // max
				}

			}

			//red

			if (img.at<Vec3b>(y,x).val[0] == 0 && img.at<Vec3b>(y,x).val[1] ==  0 && img.at<Vec3b>(y,x).val[2] == 255) 
			{
				for (int k = 0; k < 3; k++)
				{
					if (pixtmp[k] < colors_after_poster[3][0][k]) 
						colors_after_poster[3][0][k] = pixtmp[k]; // min
					if (pixtmp[k] > colors_after_poster[3][1][k])
						colors_after_poster[3][1][k] = pixtmp[k]; // max
				}

			}

			// yellow

			if (img.at<Vec3b>(y,x).val[0] == 0 && img.at<Vec3b>(y,x).val[1] ==  255 && img.at<Vec3b>(y,x).val[2] == 255) 
			{
				for (int k = 0; k < 3; k++)
				{
					if (pixtmp[k] < colors_after_poster[4][0][k]) 
						colors_after_poster[4][0][k] = pixtmp[k]; // min
					if (pixtmp[k] > colors_after_poster[4][1][k])
						colors_after_poster[4][1][k] = pixtmp[k]; // max
				}

			}

			// margenta
			if (img.at<Vec3b>(y,x).val[0] == 255 && img.at<Vec3b>(y,x).val[1] ==  0 && img.at<Vec3b>(y,x).val[2] == 255) 
			{
				for (int k = 0; k < 3; k++)
				{
					if (pixtmp[k] < colors_after_poster[5][0][k]) 
						colors_after_poster[5][0][k] = pixtmp[k]; // min
					if (pixtmp[k] > colors_after_poster[5][1][k])
						colors_after_poster[5][1][k] = pixtmp[k]; // max
				}

			}

			//cian
			if (img.at<Vec3b>(y,x).val[0] == 255 && img.at<Vec3b>(y,x).val[1] ==  255 && img.at<Vec3b>(y,x).val[2] == 0)
			{
				for (int k = 0; k < 3; k++)
				{
					if (pixtmp[k] < colors_after_poster[6][0][k]) 
						colors_after_poster[6][0][k] = pixtmp[k]; // min
					if (pixtmp[k] > colors_after_poster[6][1][k])
						colors_after_poster[6][1][k] = pixtmp[k]; // max
				}

			}

			//white
			if (img.at<Vec3b>(y,x).val[0] == 255 && img.at<Vec3b>(y,x).val[1] ==  255 && img.at<Vec3b>(y,x).val[2] == 255) 
			{
				for (int k = 0; k < 3; k++)
				{
					if (pixtmp[k] < colors_after_poster[7][0][k]) 
						colors_after_poster[7][0][k] = pixtmp[k]; // min
					if (pixtmp[k] > colors_after_poster[7][1][k])
						colors_after_poster[7][1][k] = pixtmp[k]; // max
				}

			}

		}
	}
	
	cout << endl;
	cout << "black, blue, green, red,  yellow, margenta, cian, white - min and max" << endl;
	for (int i = 0; i < 8; i++)
	{
		//if ( colors_after_poster[i][0][0] <=  colors_after_poster[i][1][0] && colors_after_poster[i][0][1] <=  colors_after_poster[i][1][1] && colors_after_poster[i][0][2] <=  colors_after_poster[i][1][2])
		//{
			cout << colors_after_poster[i][0][0] << " - "  << colors_after_poster[i][1][0] << " " << colors_after_poster[i][0][1] << " - " << colors_after_poster[i][1][1] << " " << colors_after_poster[i][0][2] << " - " <<  colors_after_poster[i][1][2] << endl;
		//}
		
	}
	imshow("posterizated", img);
	imwrite("posterizated_" + imageName, img);

	
}

