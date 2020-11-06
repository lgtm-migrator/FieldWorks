#define MAJOR_VERSION $!{FWMAJOR:0}
#define MINOR_VERSION $!{FWMINOR:0}
#define SUITE_REVISION $!{FWREVISION:0}
#define YEAR $YEAR
#define BUILD_NUMBER $BUILDNUMBER
#define STR_PRODUCT "$!{FWMAJOR:0}.$!{FWMINOR:0}.$!{FWREVISION:0}.$BUILDNUMBER\0"
#define FWSUITE_VERSION "$!{FWMAJOR:0}.$!{FWMINOR:0}.$!{FWREVISION:0}.0\0"
#define COPYRIGHT "Copyright (c) 2002-$YEAR SIL International\0"
#define COPYRIGHTRESERVED "Copyright (c) 2002-$YEAR SIL International. All rights reserved."
#define REGISTRYPATHWITHVERSION _T("Software\\SIL\\FieldWorks\\$!{FWMAJOR:0}")
