import { useState } from "react";

export default function UrlShortener() {
  const [longUrl, setLongUrl] = useState("");
  const [alias, setAlias] = useState("");
  const [shortenedUrl, setShortenedUrl] = useState(null);
  const [showConsent, setShowConsent] = useState(true);

  const handleShorten = () => {
    if (!longUrl) return;
    setShortenedUrl(`https://tinyurl.com/${alias || "random123"}`);
  };

  return (
    <div className="min-h-screen bg-gradient-to-b from-blue-900 to-blue-600 text-white flex flex-col items-center p-6">
      {/* Navbar */}
      <nav className="w-full flex justify-between max-w-5xl py-4">
        <h1 className="text-2xl font-bold">TinyURL Clone</h1>
        <div className="space-x-4">
          <button className="px-4 py-2 bg-blue-500 rounded-lg">Sign In</button>
          <button className="px-4 py-2 bg-blue-700 rounded-lg">Sign Up</button>
        </div>
      </nav>
      
      {/* Main URL Shortener Box */}
      <div className="bg-white text-gray-800 p-6 rounded-lg shadow-lg mt-10 w-full max-w-md">
        <h2 className="text-xl font-semibold mb-4">Shorten a long URL</h2>
        <input
          type="text"
          placeholder="Enter long link here"
          className="w-full p-2 border rounded mb-3"
          value={longUrl}
          onChange={(e) => setLongUrl(e.target.value)}
        />
        <div className="flex items-center space-x-2 mb-3">
          <span className="text-sm">tinyurl.com/</span>
          <input
            type="text"
            placeholder="Enter alias (optional)"
            className="w-full p-2 border rounded"
            value={alias}
            onChange={(e) => setAlias(e.target.value)}
          />
        </div>
        <div className="flex justify-center my-3 bg-gray-200 py-2 rounded">[reCAPTCHA Placeholder]</div>
        <button
          onClick={handleShorten}
          className="w-full bg-blue-500 text-white py-2 rounded mt-3"
        >
          Shorten URL
        </button>
        {shortenedUrl && (
          <p className="mt-4 text-center">Shortened URL: <a href={shortenedUrl} className="text-blue-500">{shortenedUrl}</a></p>
        )}
      </div>
      
      {/* Cookie Consent */}
      {showConsent && (
        <div className="fixed bottom-4 right-4 bg-white text-gray-800 p-4 rounded shadow-lg flex items-center space-x-4">
          <p>We use cookies to personalize your experience.</p>
          <button className="bg-blue-500 text-white px-3 py-1 rounded" onClick={() => setShowConsent(false)}>Accept</button>
        </div>
      )}
    </div>
  );
}
