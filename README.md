# libtorrent-uwp

![Github issues](https://img.shields.io/github/issues/khanhnb/libtorrent-uwp)
![Github forks](https://img.shields.io/github/forks/khanhnb/libtorrent-uwp)
![Github stars](https://img.shields.io/github/stars/khanhnb/libtorrent-uwp)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/khanhnb/libtorrent-uwp/blob/main/LICENSE)
![Twitter URL](https://img.shields.io/twitter/url?style=social&url=https%3A%2F%2Fgithub.com%2Fkhanhnb%2Flibtorrent-uwp)

libtorrent-uwp's aim is to make [amacal/leak](https://github.com/amacal/leak) work on UWP.  
Under the hood, it creates a SocketWrapper so leak can call some unsupported APIs on UWP.

# Leak #

Leak is a torrent library for .NET 4.5 written only in C#. It implements its own IO layer to fully benefit from use of windows completion ports. It also delivers sample [end user tools](https://github.com/amacal/leak/wiki/End-user) to demonstrate all its features.

## Documentation ##

Documentation is hosted on GitHub at [https://github.com/amacal/leak/wiki](https://github.com/amacal/leak/wiki).

## Sample ##

Run test-app project.  
All files are downloaded to folder TempState of your app.

## TODO ##

* Create nuget library

## License
This project uses the following license: [MIT License](https://github.com/khanhnb/libtorrent-uwp/blob/main/LICENSE).