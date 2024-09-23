using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PhotoCaptureManager : MonoBehaviour
{
    public RawImage cameraFeed;         // RawImage for live camera feed
    public Image profilePhotoDisplay;  // Image for displaying the captured photo (initially invisible)

    private WebCamTexture webCamTexture;
    private string photoPath;

    void Start()
    {
        // Find the front-facing camera
        WebCamDevice[] devices = WebCamTexture.devices;
        string frontCameraName = null;
        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing)
            {
                frontCameraName = devices[i].name;
                break;
            }
        }

        if (frontCameraName != null)
        {
            webCamTexture = new WebCamTexture(frontCameraName);
            cameraFeed.texture = webCamTexture;
            webCamTexture.Play();

            // Set profilePhotoDisplay initially invisible
            if (profilePhotoDisplay != null)
            {
                profilePhotoDisplay.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("No front-facing camera found.");
        }
    }

    public void CapturePhoto()
    {
        if (webCamTexture == null)
        {
            Debug.LogError("WebCamTexture is not initialized.");
            return;
        }

        if (webCamTexture.isPlaying)
        {
            // Capture the photo
            Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
            photo.SetPixels(webCamTexture.GetPixels());
            photo.Apply();

            // Save the photo to persistent data path
            byte[] bytes = photo.EncodeToPNG();
            photoPath = Path.Combine(Application.persistentDataPath, "capturedPhoto.png");
            File.WriteAllBytes(photoPath, bytes);

            Debug.Log("Photo saved to: " + photoPath);

            // Update the profile photo display
            if (profilePhotoDisplay != null)
            {
                Sprite newProfilePhoto = Sprite.Create(photo, new Rect(0, 0, photo.width, photo.height), new Vector2(0.5f, 0.5f));
                profilePhotoDisplay.sprite = newProfilePhoto;
                profilePhotoDisplay.gameObject.SetActive(true); // Make the profile photo visible
                Debug.Log("Profile photo updated with new image.");
            }
            else
            {
                Debug.LogError("ProfilePhotoDisplay is not assigned.");
            }

            // Stop the camera feed
            webCamTexture.Stop();

            // Hide the RawImage
            if (cameraFeed != null)
            {
                cameraFeed.gameObject.SetActive(false); // Hide the RawImage
                Debug.Log("Camera feed hidden.");
            }

            // Update the player profile with the new photo path
            PlayerProfile newProfile = new PlayerProfile("John Doe", 25, photoPath);
            PlayerProfileManager.SaveProfile(newProfile);

            Debug.Log("Profile updated with new photo path.");
        }
        else
        {
            Debug.LogError("WebCamTexture is not playing.");
        }
    }
}
