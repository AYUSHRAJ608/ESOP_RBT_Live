OPTIONS (SKIP=1,ERRORS=0,DIRECT=TRUE) LOAD DATA INFILE "D:\Ayush\ESOP_RBT_Live\ESOP\MyFolder\abc2.csv" APPEND INTO TABLE esop_tbl_exercise_dump_table fields terminated by "," optionally enclosed by '"' TRAILING NULLCOLS(DEM_EMP_ID "trim(:DEM_EMP_ID)",DEM_START_DATE "trim(:DEM_START_DATE)",DEM_END_DATE "trim(:DEM_END_DATE)",DEM_FMV_ID "trim(:DEM_FMV_ID)",DEM_FMV_PRICE "trim(:DEM_FMV_PRICE)",DEM_Taxable_Income "trim(:DEM_Taxable_Income)",DEM_ErrorString "trim(:DEM_ErrorString)",DEM_RecStatus "trim(:DEM_RecStatus)")